using Acme.BookStore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace Acme.BookStore.OrganizationUnits
{
    public class EfCoreOrganizationUnitRepository
        : EfCoreRepository<BookStoreDbContext, OrganizationUnit, Guid>,
        IOrganizationUnitRepository
    {
        public EfCoreOrganizationUnitRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public async Task<OrganizationUnit> GetByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return  dbSet.FirstOrDefault();
                }

        public async Task<List<OrganizationUnit>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {

            var dbSet = await GetDbSetAsync();
            return  await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    OrganizationUnit => OrganizationUnit.DisplayName.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}

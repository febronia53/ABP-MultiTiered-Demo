using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.PermissionGroups
{
    public class EfCorePermissionGroupRepository
        : EfCoreRepository<BookStoreDbContext, PermissionGroup, long>,
        IPermissionGroupRepository
    {
        public EfCorePermissionGroupRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<PermissionGroup> GetDetailsAsync(long id)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync();
        }

        public async Task<List<PermissionGroup>> GetListAsync()
        {
           var dbSet=await GetDbSetAsync();
            return await dbSet.ToListAsync();
        }

        public async Task<PermissionGroup> CreateAsync(PermissionGroup permissionGroup)
        {
            await DbContext.Set<PermissionGroup>().AddAsync(permissionGroup);
            await DbContext.SaveChangesAsync();
            return permissionGroup;
        }

        public async Task<PermissionGroup> UpdateAsync(long id, PermissionGroup permissionGroup)
        {
            var exisitingGroup= await DbContext.Set<PermissionGroup>().FirstOrDefaultAsync(x=>x.Id==id);
            if (exisitingGroup != null) {
                exisitingGroup.NameAr= permissionGroup.NameAr;
                exisitingGroup.NameEn= permissionGroup.NameEn;

                await DbContext.SaveChangesAsync();
            }
         return exisitingGroup;
        }
    }
}

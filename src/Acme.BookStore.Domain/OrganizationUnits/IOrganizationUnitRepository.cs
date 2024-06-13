using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Acme.BookStore.OrganizationUnits
{
    public interface IOrganizationUnitRepository:IRepository<OrganizationUnit,Guid>
    {
        Task<OrganizationUnit> GetByNameAsync(string name);

        Task<List<OrganizationUnit>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}

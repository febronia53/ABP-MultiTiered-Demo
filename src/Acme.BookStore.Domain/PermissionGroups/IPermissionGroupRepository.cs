using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.PermissionGroups
{
    public interface IPermissionGroupRepository: IRepository<PermissionGroup,long>
    {
        Task<PermissionGroup> GetDetailsAsync(long id);
        Task<List<PermissionGroup>> GetListAsync();
        Task<PermissionGroup> CreateAsync(PermissionGroup permissionGroup);
        Task<PermissionGroup> UpdateAsync(long id, PermissionGroup permissionGroup);
    }
}

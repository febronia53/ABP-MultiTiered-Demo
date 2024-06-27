using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.PermissionGroups
{
    public interface IPermissionGroupAppService : IApplicationService
    {
        Task<PermissionGroupDto> GetDetailsAsync(long id);
        Task<PagedResultDto<PermissionGroupDto>> GetListAsync();
        Task<PermissionGroupDto> CreateAsync(CreatePermissionGroupDto input);
        Task<PermissionGroupDto> UpdateAsync(long id, UpdatePermissionGroupDto input);
    }
}

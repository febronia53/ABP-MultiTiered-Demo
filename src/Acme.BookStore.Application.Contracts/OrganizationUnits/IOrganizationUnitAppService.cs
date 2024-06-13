using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Acme.BookStore.OrganizationUnits
{
    public interface IOrganizationUnitAppService:IApplicationService
    {
        
        Task<OrganizationUnitDto> GetAsync(Guid id);
        Task<PagedResultDto<OrganizationUnitDto>> GetListAsync();
        Task<OrganizationUnitDto> CreateAsync(CreateOrganizationUnitDto input);
        Task<OrganizationUnitDto> UpdateAsync(Guid id, UpdateOrganizationUnitDto input);
        Task DeleteAsync(Guid id);


    }
}

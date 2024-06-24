using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.OrganizationUnits
{
    [Authorize(BookStorePermissions.OrganizationUnits.Default)]
    public class OrganizationUnitAppService : BookStoreAppService, IOrganizationUnitAppService
    {
        private readonly IOrganizationUnitRepository _organizationUnitRepository;
        private readonly OrganizationUnitManager _organizationUnitManager;

        public OrganizationUnitAppService(IOrganizationUnitRepository organizationUnitRepository,
            OrganizationUnitManager organizationUnitManager)
        {
            _organizationUnitRepository = organizationUnitRepository;
            _organizationUnitManager = organizationUnitManager;
        }


        [Authorize(BookStorePermissions.OrganizationUnits.Create)]
        public async Task<OrganizationUnitDto> CreateAsync(CreateOrganizationUnitDto input)
        {

            var organizationUnit = new OrganizationUnit(
               GuidGenerator.Create(),
               input.DisplayName,
               CurrentTenant.Id);

            await _organizationUnitManager.CreateAsync(organizationUnit);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(organizationUnit);

        }

        [Authorize(BookStorePermissions.OrganizationUnits.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _organizationUnitManager.DeleteAsync(id);
            await CurrentUnitOfWork.SaveChangesAsync();

        }

        public async Task<OrganizationUnitDto> GetAsync(Guid id)
        {
           
            var organizationUnit= await _organizationUnitRepository.GetAsync(id);
            return ObjectMapper.Map<OrganizationUnit,OrganizationUnitDto>(organizationUnit);
        }

        public async Task<PagedResultDto<OrganizationUnitDto>> GetListAsync()
        {
            var organizationUnits = await _organizationUnitRepository.GetListAsync();
            return new PagedResultDto<OrganizationUnitDto>(
                organizationUnits.Count,
                ObjectMapper.Map<List<OrganizationUnit>,List<OrganizationUnitDto>>(organizationUnits)
                
                );
        }

        [Authorize(BookStorePermissions.OrganizationUnits.Edit)]
        public async Task<OrganizationUnitDto> UpdateAsync(Guid id, UpdateOrganizationUnitDto input)
        {
            
            var orgUnit = await _organizationUnitRepository.GetAsync(id);
            orgUnit.DisplayName = input.DisplayName;

            await _organizationUnitManager.UpdateAsync(orgUnit);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(orgUnit);
        }
       
    }
}

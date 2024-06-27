using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.PermissionGroups
{
    [Authorize(BookStorePermissions.PermissionGroups.Default)]
    public class PermissionGroupAppService : BookStoreAppService, IPermissionGroupAppService
    {
      private readonly IPermissionGroupRepository _permissionGroupRepository;

        public PermissionGroupAppService(IPermissionGroupRepository permissionGroupRepository)
        {
            _permissionGroupRepository = permissionGroupRepository;
        }
        public async Task<PermissionGroupDto> GetDetailsAsync(long id)
        {
        var group= await _permissionGroupRepository.GetAsync(id);
            return ObjectMapper.Map<PermissionGroup, PermissionGroupDto>(group);    
        }

        public async Task<PagedResultDto<PermissionGroupDto>> GetListAsync()
        {
            var groups=await _permissionGroupRepository.GetListAsync();
            var totalCount = await _permissionGroupRepository.CountAsync();
            return new PagedResultDto<PermissionGroupDto>(
                totalCount,
                ObjectMapper.Map<List<PermissionGroup>,List<PermissionGroupDto>>(groups)
                );
        }


        [Authorize(BookStorePermissions.PermissionGroups.Create)]
        public async Task<PermissionGroupDto> CreateAsync(CreatePermissionGroupDto input)
        {
            var permissionGroup= new PermissionGroup
            {
                NameAr = input.NameAr,
                NameEn = input.NameEn
            };
            var createdPermissionGroup=await _permissionGroupRepository.InsertAsync(permissionGroup);
            await CurrentUnitOfWork.SaveChangesAsync();

            return new PermissionGroupDto { 
            Id = createdPermissionGroup.Id,
            NameAr = createdPermissionGroup.NameAr,
            NameEn = createdPermissionGroup.NameEn,
            Name= Thread.CurrentThread.CurrentCulture
            .TwoLetterISOLanguageName=="ar"?createdPermissionGroup.NameAr
            :createdPermissionGroup.NameEn
            };
        }

        [Authorize(BookStorePermissions.PermissionGroups.Edit)]
        public async Task<PermissionGroupDto> UpdateAsync(long id, UpdatePermissionGroupDto input)
        {
        var group= await _permissionGroupRepository.GetAsync(id);

            if(group.NameEn!= input.NameEn|| group.NameAr != input.NameAr)
            {
                group.NameEn = input.NameEn;
                group.NameAr = input.NameAr;
            }
            var updatedPermissionGroup = await _permissionGroupRepository.UpdateAsync(group);

            return new PermissionGroupDto
            {
                Id = updatedPermissionGroup.Id,
                NameAr = updatedPermissionGroup.NameAr,
                NameEn = updatedPermissionGroup.NameEn,
                Name = Thread.CurrentThread.CurrentCulture
            .TwoLetterISOLanguageName == "ar" ? updatedPermissionGroup.NameAr
            : updatedPermissionGroup.NameEn
            };
        }
    }
}

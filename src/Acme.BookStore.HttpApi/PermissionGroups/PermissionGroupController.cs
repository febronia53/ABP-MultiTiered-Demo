using Acme.BookStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.PermissionGroups
{
    [Route("api/Permission-Group")]
    public class PermissionGroupController : BookStoreController
    {
        private readonly IPermissionGroupAppService _permissionGroupAppService;

        public PermissionGroupController(IPermissionGroupAppService permissionGroupAppService)
        {
            _permissionGroupAppService = permissionGroupAppService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailsAsync(long id)
        {
            var group = await _permissionGroupAppService.GetDetailsAsync(id);
            return group == null ? NotFound() : Ok(group);
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var groups = await _permissionGroupAppService.GetListAsync();
            return Ok(groups);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePermissionGroupDto groupDto)
        {
            await _permissionGroupAppService.CreateAsync(groupDto);
            return Ok(StatusCode(200));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, UpdatePermissionGroupDto groupDto)
        {
            await _permissionGroupAppService.UpdateAsync(id, groupDto);
            return Ok(StatusCode(200));
        }
    }
}

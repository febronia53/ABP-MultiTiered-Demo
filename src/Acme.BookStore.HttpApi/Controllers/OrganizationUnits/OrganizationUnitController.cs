using Acme.BookStore.OrganizationUnits;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Controllers.OrganizationUnits
{
    [Route("api/organization-unit")]
    public class OrganizationUnitController: BookStoreController
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;

        public OrganizationUnitController(IOrganizationUnitAppService organizationUnitAppService)
        {
            _organizationUnitAppService = organizationUnitAppService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationAsync(Guid id)
        {
            var orgUnit = await _organizationUnitAppService.GetAsync(id);
            if (orgUnit == null)
            {
                return NotFound();
            }
            return Ok(orgUnit);
        }

        [HttpGet]
        public async Task<ActionResult> GetOrganizationUnitsList()
        {
            var orgUnitList = await _organizationUnitAppService.GetListAsync();
            return Ok(orgUnitList);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrganizationUnit(CreateOrganizationUnitDto orgUnit)
        {
            await _organizationUnitAppService.CreateAsync(orgUnit);
            return Ok(StatusCode(200));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrganization(Guid id)
        {
            await _organizationUnitAppService.DeleteAsync(id);
            return Ok(StatusCode(200));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrganizationUnit(Guid id, UpdateOrganizationUnitDto orgUnit)
        {
            await _organizationUnitAppService.UpdateAsync(id, orgUnit);
            return Ok(StatusCode(200));
        }
    }
}


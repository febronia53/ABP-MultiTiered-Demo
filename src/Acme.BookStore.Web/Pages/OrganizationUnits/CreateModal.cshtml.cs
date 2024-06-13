using System;
using System.Threading.Tasks;
using Acme.BookStore.OrganizationUnits;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.OrganizationUnits
{
    public class CreateModalModel : BookStorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateOrganizationUnitDto OrganizationUnit { get; set; }

        private readonly IOrganizationUnitAppService _organizationUnitAppService;

        public CreateModalModel(IOrganizationUnitAppService organizationUnitAppService)
        {
            _organizationUnitAppService = organizationUnitAppService;
        }

        public void OnGet()
        {
            //OrganizationUnit = new CreateOrganizationUnitDto
            //{
            //    Id = Guid.NewGuid() 
            //};
            OrganizationUnit=new CreateOrganizationUnitDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _organizationUnitAppService.CreateAsync(OrganizationUnit);
            return NoContent();
        }
    }
}

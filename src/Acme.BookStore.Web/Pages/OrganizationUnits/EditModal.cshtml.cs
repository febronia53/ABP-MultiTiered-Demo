using System;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Acme.BookStore.OrganizationUnits;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.OrganizationUnits;

public class EditModalModel : BookStorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public UpdateOrganizationUnitDto OrganizationUnitDto { get; set; }

    private readonly IOrganizationUnitAppService _organizationUnitAppService;

    public EditModalModel(IOrganizationUnitAppService organizationUnitAppService)
    {
        _organizationUnitAppService = organizationUnitAppService;
    }

    public async Task OnGetAsync()
    {
        var orgDto = await _organizationUnitAppService.GetAsync(Id);
        OrganizationUnitDto = ObjectMapper.Map<OrganizationUnitDto, UpdateOrganizationUnitDto>(orgDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _organizationUnitAppService.UpdateAsync(Id, OrganizationUnitDto);
        return NoContent();
    }
}

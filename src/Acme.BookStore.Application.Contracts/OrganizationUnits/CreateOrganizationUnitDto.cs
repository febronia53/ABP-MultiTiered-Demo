using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;
using Acme.BookStore.OrganizataionUnits;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.OrganizationUnits
{
    public class CreateOrganizationUnitDto
    {
        //[HiddenInput]
        //[BindProperty(SupportsGet = true)]
        //public Guid Id { get; set; }

        [Required]
        [StringLength(OrganizationUnitConsts.MaxDisplayNameLength)]
        public string DisplayName { get; set; }
        //public Guid? ParentId { get; set; }
        //public Guid? TenantId { get; set; }
        //public string? Code { get; set; }
    }
}

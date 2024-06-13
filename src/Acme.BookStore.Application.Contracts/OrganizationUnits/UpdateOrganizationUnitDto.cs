using Acme.BookStore.OrganizataionUnits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.OrganizationUnits
{
    public class UpdateOrganizationUnitDto
    {
        //public Guid Id { get; set; }
        //[Required]
        //[StringLength(OrganizationUnitConsts.MaxDisplayNameLength)]
        public string DisplayName { get; set; }
        //public Guid? ParentId { get; set; }
        //public Guid? TenantId { get; set; }

        //public string Code { get; set; }
    }
}

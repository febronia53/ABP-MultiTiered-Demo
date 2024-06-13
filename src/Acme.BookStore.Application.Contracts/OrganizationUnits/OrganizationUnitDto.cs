using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.OrganizationUnits
{
    public class OrganizationUnitDto: EntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? TenantId { get; set; }

        public string Code { get; set; }

    }
}

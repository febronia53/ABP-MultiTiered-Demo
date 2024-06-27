using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Acme.BookStore.PermissionGroups
{
    public class CreatePermissionGroupDto
    {
        [Required]
        [StringLength(PermissionGroupConsts.MaxNameLength)]
        public string NameAr { get; set; }


        [Required]
        [StringLength(PermissionGroupConsts.MaxNameLength)]
        public string NameEn { get; set; }
    }
}

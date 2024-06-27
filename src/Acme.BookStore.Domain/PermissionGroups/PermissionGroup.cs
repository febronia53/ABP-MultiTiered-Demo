using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.PermissionGroups
{
    public class PermissionGroup :  FullAuditedAggregateRoot<long>, IAggregateRoot
    {
        public long Id { get; set; }
        public string NameAr { get; set; }

        public string NameEn { get; set; }

        [NotMapped]
        public string Name
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "ar" ? NameAr : NameEn;
            }
        }
        public object?[] GetKeys()
        {
            return new object?[] { Id };
        }
    }
}

using Acme.BookStore.Authors;
using Acme.BookStore.OrganizationUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.BookStore.EntityFrameworkCore.Applications.OrganizationUnits
{
   
    [Collection(BookStoreTestConsts.CollectionDefinitionName)]
    public class EfCoreOrganizationUnitAppService_Tests : OrganizationUnitAppService_Tests<BookStoreEntityFrameworkCoreTestModule>
    {

    }
}

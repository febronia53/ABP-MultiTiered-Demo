using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.BookStore.OrganizationUnits
{
    public class OrganizationUnitConstsTests
    {
        [Fact]
        public void MaxDisplayNameLength_Should_Be_Equal()
        {
            // Arrange
            int expectedMaxDisplayNameLength = Volo.Abp.Identity.OrganizationUnitConsts.MaxDisplayNameLength;

            // Act
            int actualMaxDisplayNameLength = Acme.BookStore.OrganizataionUnits.OrganizationUnitConsts.MaxDisplayNameLength;

            // Assert
            Assert.Equal(expectedMaxDisplayNameLength, actualMaxDisplayNameLength);
        }

    }
}

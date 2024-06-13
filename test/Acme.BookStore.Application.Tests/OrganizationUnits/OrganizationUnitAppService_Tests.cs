using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;
using Xunit.Sdk;

namespace Acme.BookStore.OrganizationUnits
{
      public abstract class OrganizationUnitAppService_Tests<TStartupModule> : BookStoreApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;

        protected OrganizationUnitAppService_Tests()
        {
            _organizationUnitAppService = GetRequiredService<IOrganizationUnitAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Organizations_Without_Any_Filter()
        {
            var result = await _organizationUnitAppService.GetListAsync();

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(0);
            result.Items.ShouldContain(orgUnit => orgUnit.DisplayName == "Ejada");
            result.Items.ShouldContain(orgUnit => orgUnit.DisplayName == "Ejada2");
        }


        [Fact]
        public async Task Should_Create_A_New_OrganizationUnit()
        {
            var organizationUnitDto = await _organizationUnitAppService.CreateAsync(
                new CreateOrganizationUnitDto()
                {
                    DisplayName = "Ejada Test"
                   
                }
            );

            organizationUnitDto.Id.ShouldNotBe(Guid.Empty);
            organizationUnitDto.DisplayName.ShouldBe("Ejada Test");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_OrganizationUnits()
        {
            await Assert.ThrowsAsync<ThrowsException>(async () =>
            {
                await _organizationUnitAppService.CreateAsync(
                    new CreateOrganizationUnitDto
                    {
                        DisplayName = "Ejada"
                       
                    }
                );
            });
        }

        
    }

}

using Microsoft.Extensions.Logging;
using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Modularity;
using Xunit;

namespace Acme.BookStore.OrganizationUnits
{
    public abstract class OrganizationUnitAppService_Tests<TStartupModule> : BookStoreApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;
        private readonly ILogger<OrganizationUnitAppService_Tests<TStartupModule>> _logger;

        protected OrganizationUnitAppService_Tests()
        {
            _organizationUnitAppService = GetRequiredService<IOrganizationUnitAppService>();
            _logger = GetRequiredService<ILogger<OrganizationUnitAppService_Tests<TStartupModule>>>();
        }

        [Fact]
        public async Task Should_Get_All_Organizations()
        {
            // Act
            _logger.LogInformation("Fetching organizations...");
            var result = await _organizationUnitAppService.GetListAsync();

            // Log retrieved data
            _logger.LogInformation($"Retrieved {result.TotalCount} organizations.");

            // Assert
            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(orgUnit => orgUnit.DisplayName == "Ejada");
            result.Items.ShouldContain(orgUnit => orgUnit.DisplayName == "Ejada System");
        }

        [Fact]
        public async Task Should_Create_A_New_OrganizationUnit()
        {
            // Act
            var organizationUnitDto = await _organizationUnitAppService.CreateAsync(
                new CreateOrganizationUnitDto
                {
                    DisplayName = "Ejada Test"
                }
            );

            // Assert
            organizationUnitDto.Id.ShouldNotBe(Guid.Empty);
            organizationUnitDto.DisplayName.ShouldBe("Ejada Test");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_OrganizationUnits()
        {
            // Arrange
            var existingOrgUnit = await _organizationUnitAppService.CreateAsync(
                new CreateOrganizationUnitDto
                {
                    DisplayName = "Ejada"
                }
            );

            // Act & Assert
            await Assert.ThrowsAsync<BusinessException>(async () =>
            {
                await _organizationUnitAppService.CreateAsync(
                    new CreateOrganizationUnitDto
                    {
                        DisplayName = "Ejada"
                    }
                );
            });
        }

        [Fact]
        public async Task Should_Get_Specific_OrganizationUnit_By_Id()
        {
            // Arrange
            var newOrgUnit = await _organizationUnitAppService.CreateAsync(
                new CreateOrganizationUnitDto
                {
                    DisplayName = "Test Organization Unit"
                }
            );

            // Act
            var retrievedOrgUnit = await _organizationUnitAppService.GetAsync(newOrgUnit.Id);

            // Assert
            retrievedOrgUnit.ShouldNotBeNull();
            retrievedOrgUnit.Id.ShouldBe(newOrgUnit.Id);
            retrievedOrgUnit.DisplayName.ShouldBe("Test Organization Unit");
        }

        [Fact]
        public async Task Should_Update_OrganizationUnit()
        {
            // Arrange
            var newOrgUnit = await _organizationUnitAppService.CreateAsync(
                new CreateOrganizationUnitDto
                {
                    DisplayName = "OrgUnitToUpdate"
                }
            );

            var updateDto = new UpdateOrganizationUnitDto
            {
                //Id = newOrgUnit.Id,
                DisplayName = "Updated OrgUnit"
            };

            // Act
            await _organizationUnitAppService.UpdateAsync(newOrgUnit.Id, updateDto);
            var updatedOrgUnit = await _organizationUnitAppService.GetAsync(newOrgUnit.Id);

            // Assert
            updatedOrgUnit.ShouldNotBeNull();
            updatedOrgUnit.Id.ShouldBe(newOrgUnit.Id);
            updatedOrgUnit.DisplayName.ShouldBe("Updated OrgUnit");
        }

        [Fact]
        public async Task Should_Delete_OrganizationUnit()
        {
            // Arrange
            var newOrgUnit = await _organizationUnitAppService.CreateAsync(
                new CreateOrganizationUnitDto
                {
                    DisplayName = "OrgUnitToDelete"
                }
            );

            // Act
            await _organizationUnitAppService.DeleteAsync(newOrgUnit.Id);

            // Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await _organizationUnitAppService.GetAsync(newOrgUnit.Id);
            });
        }
    }
}

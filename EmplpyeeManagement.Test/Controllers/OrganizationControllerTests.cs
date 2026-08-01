using EmployeeManagement.Api.Controller;
using EmployeeManagement.Api.Dtos.Organization;
using EmployeeManagements.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmplpyeeManagement.Test.Controllers
{
    public class OrganizationControllerTests
    {
        private readonly Mock<IOrganizationService> _serviceMock;
        private readonly OrganizationController _controller;

        public OrganizationControllerTests()
        {
            _serviceMock = new Mock<IOrganizationService>();

            _controller = new OrganizationController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAll_Should_Return_OkResult_With_Organizations()
        {
            // Arrange
            var organizations = new List<OrganizationResponse>
        {
            new OrganizationResponse(1, "Google", DateTime.Now,null),
            new OrganizationResponse(2, "Microsoft", DateTime.Now,null)
        };

            _serviceMock
                .Setup(s => s.GetAllOrganizationsAsync())
                .ReturnsAsync(organizations);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var data = Assert.IsAssignableFrom<IEnumerable<OrganizationResponse>>(okResult.Value);

            Assert.Equal(2, data.Count());
        }

    }
}

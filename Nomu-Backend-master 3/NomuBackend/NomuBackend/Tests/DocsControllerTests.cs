using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Xunit;
using NomuBackend.Controllers;

namespace YourProject.Tests
{
    public class DocsControllerTests
    {
        private readonly DocsController _controller;
        private readonly Mock<IMongoDatabase> _mockDatabase;

        public DocsControllerTests()
        {
            // Mock IMongoDatabase
            _mockDatabase = new Mock<IMongoDatabase>();

            // DocsController'a mock database'i geçiyoruz
            _controller = new DocsController(_mockDatabase.Object);
        }

        [Fact]
        public void CreateDoc_ShouldReturnCreatedResult()
        {
            var doc = new Docs
            {
                DocId = "123",
                DocType = "Word",
                DocContent = "Sample content",
                ProductCatalogue = "Catalogue",
                StaffInfo = "Staff details",
                ContactInfo = "Contact details"
            };

            var result = _controller.CreateDoc(doc);

            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void GetDocById_ShouldReturnNotFound()
        {
            var result = _controller.GetDocById("invalid_id");

            Assert.IsType<NotFoundResult>(result);
        }
    }

    internal class Mock<T>
    {
        public IMongoDatabase Object { get; internal set; }
    }
}

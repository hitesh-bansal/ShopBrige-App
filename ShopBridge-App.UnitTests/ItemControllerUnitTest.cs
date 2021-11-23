using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopBrige_App.Controllers.Api;
using ShopBrige_App.DTOs;
using ShopBrige_App.Models;
using ShopBrige_App.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ShopBridge_App.UnitTests
{
    [TestClass]
    public class ItemControllerUnitTest
    {
        private Mock<IItems> mockRepo;

        [TestMethod]
        public void GetItems_Returns_AllItems()
        {
            //Arrange
            mockRepo = new Mock<IItems>();
            IEnumerable<ItemDto> duplicateItemDTOs = GetDuplicateItems();
            mockRepo.Setup(x => x.GetItems()).Returns(duplicateItemDTOs.AsQueryable());
            var controller = new ItemsController(mockRepo.Object);

            //Act
            var items = controller.GetItems();

            //Assert
            Assert.AreEqual(2, items.Count(), "Wrong Count.");
        }

        [TestMethod]
        public void GetItemById_Returns_Item()
        {
            // Arrange   
            mockRepo = new Mock<IItems>();
            IEnumerable<ItemDto> duplicateItemDTOs = GetDuplicateItems();
            mockRepo.Setup(x => x.GetItem(1)).Returns(duplicateItemDTOs.Where(x => x.ID == 1).FirstOrDefault());

            var controller = new ItemsController(mockRepo.Object);

            // Act
            var actionResult = controller.GetItem(1);
            var contentResult = actionResult as OkNegotiatedContentResult<ItemDto>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(1, contentResult.Content.ID, "Got wrong Item.");
        }

        [TestMethod]
        public void GetItemById_WrongID_Returns_Exception()
        {
            // Arrange   
            mockRepo = new Mock<IItems>();
            IEnumerable<ItemDto> duplicateItemDTOs = GetDuplicateItems();
            mockRepo.Setup(x => x.GetItem(10)).Returns(duplicateItemDTOs.Where(x => x.ID == 10).FirstOrDefault());

            var controller = new ItemsController(mockRepo.Object);

            // Act
            var actionResult = controller.GetItem(10);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Post_InventoryItem_Returns_OK()
        {
            // Arrange
            var controller = new ItemsController(mockRepo.Object);

            // Act
            IHttpActionResult actionResult =  controller.CreateItem(null);
            var createdResult = actionResult as NegotiatedContentResult<string>;

            // Assert            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        private static IEnumerable<ItemDto> GetDuplicateItems()
        {
            IEnumerable<ItemDto> DuplicateItems = new List<ItemDto>
            {
                    new ItemDto {ID=1,Name="item1",Description="desc1",Price=100,Quantity=1 },
                    new ItemDto {ID=2,Name="item2",Description="desc2",Price=150,Quantity=2 },
            }.AsEnumerable();
            return DuplicateItems;
        }
    }
}

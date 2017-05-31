using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sample.WebAPI.Controllers;
using Sample.WebAPI.Models;
using Sample.WebAPI.Services;
using Sample.WebAPI.Tests.TestHelpers;
using Sample.WebAPI.ViewModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace Sample.WebAPI.Tests.Controller
{
    /// <summary>
    /// Tests for Resource controller
    /// </summary>
    [TestClass]
    public class ResourceControllerTests
    {
        private ResourcesController controller;
        private Mock<IResourceService> service;

        [TestInitialize]
        public void SetUp()
        {
            service = new Mock<IResourceService>();
            controller = new ResourcesController(service.Object);
        }

        [TestMethod]
        public void Get_Method_Should_Return_All_Resource_Data()
        {
            // Arrange
            service.Setup(r => r.Get(It.IsAny<int>())).Returns(ResourceData.getResourceResponse());
            var projectId = 1;

            //Act
            IHttpActionResult actionResult = controller.Get(projectId);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<IEnumerable<ResourceModel>>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, contentResult.Content.Success);
            Assert.IsNotNull(contentResult.Content.Content);
        }

        [TestMethod]
        public void Get_Method_Should_Return_Invalid_Response()
        {
            // Arrange
            service.Setup(r => r.Get(It.IsAny<int>())).Returns(ResourceData.getInvalidResourceResponse());
            var projectId = 1;

            //Act
            IHttpActionResult actionResult = controller.Get(projectId);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<IEnumerable<ResourceModel>>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content.Success);
            Assert.AreEqual("Invalid Response", contentResult.Content.Message);
            Assert.IsNull(contentResult.Content.Content);
        }

        [TestMethod]
        public void Post_Method_Should_Return_Success_Response()
        {
            // Arrange
            service.Setup(s => s.Add(It.IsAny<ProjectPeople>())).Returns(ResourceData.addResourceResponse());
            var resource = new ProjectPeople()
            {
                ProjectId = 1,
                PeopleId = 2,
                Description = ".Net Developer"
            };

            //Act
            IHttpActionResult actionResult = controller.Post(resource);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<ResourceModel>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, contentResult.Content.Success);
            Assert.IsNotNull(contentResult.Content.Content);
            Assert.AreEqual(1, contentResult.Content.Content.Id);
            Assert.AreEqual(1, contentResult.Content.Content.PeopleId);
            Assert.AreEqual(1, contentResult.Content.Content.ProjectId);
            Assert.IsNotNull(contentResult.Content.Content.Person);
        }

        [TestMethod]
        public void Post_Method_Should_Return_Invalid_Response()
        {
            // Arrange
            service.Setup(s => s.Add(It.IsAny<ProjectPeople>())).Returns(ResourceData.addInvalidResourceResponse());
            var resource = new ProjectPeople()
            {
                ProjectId = 1,
                PeopleId = 2,
                Description = ".Net Developer"
            };

            //Act
            IHttpActionResult actionResult = controller.Post(resource);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<ResourceModel>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content.Success);
            Assert.AreEqual("Invalid Response", contentResult.Content.Message);
            Assert.IsNull(contentResult.Content.Content);
        }
    }
}

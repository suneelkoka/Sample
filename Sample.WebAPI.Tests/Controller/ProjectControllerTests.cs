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
    /// Tests for Project controller
    /// </summary>
    [TestClass]
    public class ProjectControllerTests
    {
        private ProjectController controller;
        private Mock<IProjectService> service;

        [TestInitialize]
        public void SetUp()
        {
            service = new Mock<IProjectService>();
            controller = new ProjectController(service.Object);
        }

        [TestMethod]
        public void Get_Method_Should_Return_All_Projects_Data()
        {
            // Arrange
            service.Setup(r => r.Get()).Returns(ProjectData.getProjectResponse());

            //Act
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<IEnumerable<ProjectModel>>>;

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
            service.Setup(r => r.Get()).Returns(ProjectData.getInvalidProjectResponse());

            //Act
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<IEnumerable<ProjectModel>>>;

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
            service.Setup(s => s.Add(It.IsAny<Project>())).Returns(ProjectData.addProjectResponse());
            var project = new Project()
            {
                Name = "EMS",
                Description = "Employee management system"
            };

            //Act
            IHttpActionResult actionResult = controller.Post(project);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<ProjectModel>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, contentResult.Content.Success);
            Assert.IsNotNull(contentResult.Content.Content);
            Assert.AreEqual(1, contentResult.Content.Content.Id);
        }

        [TestMethod]
        public void Post_Method_Should_Return_Invalid_Response()
        {
            // Arrange
            service.Setup(s => s.Add(It.IsAny<Project>())).Returns(ProjectData.addInvalidProjectResponse());
            var project = new Project()
            {
                Name = "EMS",
                Description = "Employee management system"
            };

            //Act
            IHttpActionResult actionResult = controller.Post(project);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<ProjectModel>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content.Success);
            Assert.AreEqual("Invalid Response", contentResult.Content.Message);
            Assert.IsNull(contentResult.Content.Content);
        }
    }
}

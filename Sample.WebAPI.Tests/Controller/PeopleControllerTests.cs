using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.WebAPI.Controllers;
using Moq;
using Sample.WebAPI.Services;
using Sample.WebAPI.Tests.TestHelpers;
using System.Web.Http;
using System.Web.Http.Results;
using Sample.WebAPI.ViewModels;
using System.Collections.Generic;
using Sample.WebAPI.Models;

namespace Sample.WebAPI.Tests.Controller
{
    /// <summary>
    /// Tests for People controller
    /// </summary>
    [TestClass]
    public class PeopleControllerTests
    {
        private PeopleController controller;
        private Mock<IPeopleService> service;

        [TestInitialize]
        public void SetUp()
        {
            service = new Mock<IPeopleService>();
            controller = new PeopleController(service.Object);
        }

        [TestMethod]
        public void Get_Method_Should_Return_All_People_Data()
        {
            // Arrange
            service.Setup(r => r.Get()).Returns(PeopleData.getPeopleResponse());

            //Act
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<IEnumerable<PeopleModel>>>;

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
            service.Setup(r => r.Get()).Returns(PeopleData.getInvalidPeopleResponse());

            //Act
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<IEnumerable<PeopleModel>>>;

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
            service.Setup(s => s.Add(It.IsAny<Person>())).Returns(PeopleData.addPeopleResponse());
            var person = new Person()
            {
                FirstName = "Suneel",
                LastName = "Koka",
                Email = "skoka@test.com",
                Mobile = "0452339394",
                Address = "Kogarah"
            };

            //Act
            IHttpActionResult actionResult = controller.Post(person);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<PeopleModel>>;

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
            service.Setup(s => s.Add(It.IsAny<Person>())).Returns(PeopleData.addInvalidPeopleResponse());
            var person = new Person()
            {
                FirstName = "Suneel",
                LastName = "Koka",
                Email = "skoka@test.com",
                Mobile = "0452339394",
                Address = "Kogarah"
            };

            //Act
            IHttpActionResult actionResult = controller.Post(person);
            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<PeopleModel>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content.Success);
            Assert.AreEqual("Invalid Response", contentResult.Content.Message);
            Assert.IsNull(contentResult.Content.Content);
        }
    }
}

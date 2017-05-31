//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Sample.WebAPI.Controllers;
//using Moq;
//using Sample.WebAPI.Repositories;
//using Sample.WebAPI.Models;
//using Sample.WebAPI.ViewModels;
//using System.Collections.Generic;
//using System.Collections;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Results;
//using Sample.WebAPI.Services;

//namespace Sample.WebAPI.Tests
//{
//    //[TestClass]
//    public class UnitTest1
//    {
//        //[TestMethod]
//        public void TestMethod1()
//        {
//            // Arrange
//            var service = new Mock<IPeopleService>();

//            service.Setup(r => r.Get()).Returns(getPeopleResponse());

//            var controller = new PeopleController(service.Object);
//            //controller.Request = new HttpRequestMessage();
//            //controller.Configuration = new HttpConfiguration();

//           // var response = controller.Get();

//            // Assert
//            //ResponseModel<IEnumerable<PeopleModel>> result;
//            //Assert.IsTrue(response.TryGetContentValue<ResponseModel<IEnumerable<PeopleModel>>>(out result));
//            //Assert.AreEqual(10, product.Id);
//            IHttpActionResult actionResult = controller.Get();
//            var contentResult = actionResult as OkNegotiatedContentResult<ResponseModel<IEnumerable<PeopleModel>>>;

//            // Assert
//            Assert.IsNotNull(contentResult);
//            Assert.IsNotNull(contentResult.Content);
//            Assert.AreEqual(true, contentResult.Content.Success);
//        }


//        private ResponseModel<IEnumerable<PeopleModel>> getPeopleResponse()
//        {
//           // var result = new List<PeopleModel>();
//           var people = new List<PeopleModel>()
//            {
//                new PeopleModel()
//                {
//                    Id = 1,
//                    FirstName = "Suneel",
//                    LastName = "Koka",
//                    Email = "skoka@test.com",
//                    Mobile = "0452339394",
//                    Address = "Kogarah"
//                },
//                 new PeopleModel()
//                {
//                    Id = 2,
//                    FirstName = "James",
//                    LastName = "Miller",
//                    Email = "jmiller@test.com",
//                    Mobile = "0455222444",
//                    Address = "Sydney"
//                }
//            };

//            return ResponseHelper.CreateSuccessResponse<IEnumerable<PeopleModel>>(people);
//        }

//    }
//}

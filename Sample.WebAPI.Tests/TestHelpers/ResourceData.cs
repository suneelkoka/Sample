using Sample.WebAPI.Models;
using Sample.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.WebAPI.Tests.TestHelpers
{
    /// <summary>
    /// Class is responsible to return mock data for resource
    /// </summary>
    public class ResourceData
    {
        public static ResponseModel<IEnumerable<ResourceModel>> getResourceResponse()
        {
            return ResponseHelper.CreateSuccessResponse<IEnumerable<ResourceModel>>(GetMockData());
        }

        public static ResponseModel<IEnumerable<ResourceModel>> getInvalidResourceResponse()
        {
            return ResponseHelper.CreateFailureResponse<IEnumerable<ResourceModel>>("Invalid Response");
        }

        public static ResponseModel<ResourceModel> addResourceResponse()
        {
            return ResponseHelper.CreateSuccessResponse<ResourceModel>(GetMockData()[0]);
        }

        public static ResponseModel<ResourceModel> addInvalidResourceResponse()
        {
            return ResponseHelper.CreateFailureResponse<ResourceModel>("Invalid Response");
        }

        public static IList<ResourceModel> GetMockData()
        {
            return new List<ResourceModel>()
            {
                new ResourceModel()
                {
                    Id = 1,
                    ProjectId = 1,
                    PeopleId = 1,
                    Description = ".Net Developer",
                    Person = new PeopleModel()
                    {
                        Id = 1,
                        FirstName = "Suneel",
                        LastName = "Koka",
                        Email = "skoka@test.com",
                        Mobile = "0452339394",
                        Address = "Kogarah"
                    }
                },
                 new ResourceModel()
                {
                    Id = 1,
                    ProjectId = 1,
                    PeopleId = 2,
                    Description = "Project Manager",
                    Person = new PeopleModel()
                    {
                        Id = 2,
                        FirstName = "James",
                        LastName = "Miller",
                        Email = "jmiller@test.com",
                        Mobile = "0455222444",
                        Address = "Sydney"
                    }
                }
            };
        }
    }
}

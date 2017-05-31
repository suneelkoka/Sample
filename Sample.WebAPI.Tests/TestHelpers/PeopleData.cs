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
    /// Class is responsible to return mock data for people
    /// </summary>
    public class PeopleData
    {
        public static ResponseModel<IEnumerable<PeopleModel>> getPeopleResponse()
        {
            return ResponseHelper.CreateSuccessResponse<IEnumerable<PeopleModel>>(GetMockData());
        }

        public static ResponseModel<IEnumerable<PeopleModel>> getInvalidPeopleResponse()
        {
            return ResponseHelper.CreateFailureResponse<IEnumerable<PeopleModel>>("Invalid Response");
        }

        public static ResponseModel<PeopleModel> addPeopleResponse()
        {
            return ResponseHelper.CreateSuccessResponse<PeopleModel>(GetMockData()[0]);
        }

        public static ResponseModel<PeopleModel> addInvalidPeopleResponse()
        {
            return ResponseHelper.CreateFailureResponse<PeopleModel>("Invalid Response");
        }

        public static IList<PeopleModel> GetMockData()
        {
            return new List<PeopleModel>()
            {
                new PeopleModel()
                {
                    Id = 1,
                    FirstName = "Suneel",
                    LastName = "Koka",
                    Email = "skoka@test.com",
                    Mobile = "0452339394",
                    Address = "Kogarah"
                },
                 new PeopleModel()
                {
                    Id = 2,
                    FirstName = "James",
                    LastName = "Miller",
                    Email = "jmiller@test.com",
                    Mobile = "0455222444",
                    Address = "Sydney"
                }
            };
        }
    }
}

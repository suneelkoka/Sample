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
    /// Class is responsible to return mock data for project
    /// </summary>
    public class ProjectData
    {
        public static ResponseModel<IEnumerable<ProjectModel>> getProjectResponse()
        {
            return ResponseHelper.CreateSuccessResponse<IEnumerable<ProjectModel>>(GetMockData());
        }

        public static ResponseModel<IEnumerable<ProjectModel>> getInvalidProjectResponse()
        {
            return ResponseHelper.CreateFailureResponse<IEnumerable<ProjectModel>>("Invalid Response");
        }

        public static ResponseModel<ProjectModel> addProjectResponse()
        {
            return ResponseHelper.CreateSuccessResponse<ProjectModel>(GetMockData()[0]);
        }

        public static ResponseModel<ProjectModel> addInvalidProjectResponse()
        {
            return ResponseHelper.CreateFailureResponse<ProjectModel>("Invalid Response");
        }

        public static IList<ProjectModel> GetMockData()
        {
            return new List<ProjectModel>()
            {
                new ProjectModel()
                {
                    Id = 1,
                    Name = "EMS",
                    Description = "Employee management system"
                },
                 new ProjectModel()
                {
                    Id = 2,
                    Name = "CMS",
                    Description = "Content management system"
                }
            };
        }

        public static IList<Project> GetDbMockData()
        {
            return new List<Project>()
            {
                new Project()
                {
                    Id = 1,
                    Name = "EMS",
                    Description = "Employee management system"
                },
                 new Project()
                {
                    Id = 2,
                    Name = "CMS",
                    Description = "Content management system"
                }
            };
        }
    }
}

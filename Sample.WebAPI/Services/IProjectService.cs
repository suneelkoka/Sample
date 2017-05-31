using Sample.WebAPI.Models;
using Sample.WebAPI.ViewModels;
using System.Collections.Generic;

namespace Sample.WebAPI.Services
{
    /// <summary>
    /// Interface for Project service
    /// </summary>
    public interface IProjectService
    {
        ResponseModel<IEnumerable<ProjectModel>> Get();
        ResponseModel<ProjectModel> Add(Project project);
    }
}

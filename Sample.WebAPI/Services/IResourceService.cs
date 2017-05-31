using Sample.WebAPI.Models;
using Sample.WebAPI.ViewModels;
using System.Collections.Generic;

namespace Sample.WebAPI.Services
{
    /// <summary>
    /// Interface for Resource service
    /// </summary>
    public interface IResourceService
    {
        ResponseModel<IEnumerable<ResourceModel>> Get(int projectId);
        ResponseModel<ResourceModel> Add(ProjectPeople resource);
    }
}

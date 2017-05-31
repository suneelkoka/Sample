using Sample.WebAPI.Models;
using System.Collections.Generic;

namespace Sample.WebAPI.Repositories
{
    /// <summary>
    /// Resource repository interface
    /// </summary>
    public interface IResourceRepository
    {
        IEnumerable<ProjectPeople> Get(int projectId);
        ProjectPeople Add(ProjectPeople resource);
        ProjectPeople GetResource(int projectId, int personId);
    }
}

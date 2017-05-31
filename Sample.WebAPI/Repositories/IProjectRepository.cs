using Sample.WebAPI.Models;
using System.Collections.Generic;

namespace Sample.WebAPI.Repositories
{
    /// <summary>
    /// Project repository interface
    /// </summary>
    public interface IProjectRepository
    {
        IEnumerable<Project> Get();
        Project Add(Project project);
    }
}

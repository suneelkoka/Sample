using Sample.WebAPI.Models;
using System.Collections.Generic;

namespace Sample.WebAPI.Repositories
{
    /// <summary>
    /// Project repository responsible for project entity database operations
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {
        private SampleDatabaseEntities dbContext = new SampleDatabaseEntities();

        /// <summary>
        /// Get projects
        /// </summary>
        /// <returns>
        /// Returns projects list
        /// </returns>
        public IEnumerable<Project> Get()
        {
            return dbContext.Projects;
        }

        /// <summary>
        /// Save project entity
        /// </summary>
        /// <param name="project"></param>
        /// <returns>
        /// Save and return project entity
        /// </returns>
        public Project Add(Project project)
        {
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
                    
            return project;
        }
    }
}
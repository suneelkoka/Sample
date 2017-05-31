using Sample.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sample.WebAPI.Repositories
{
    /// <summary>
    /// Resource repository responsible for projectpeople entity database operations
    /// </summary>
    public class ResourceRepository : IResourceRepository
    {
        private SampleDatabaseEntities dbContext = new SampleDatabaseEntities();

        /// <summary>
        /// save projectpeople entity
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public ProjectPeople Add(ProjectPeople resource)
        {
            dbContext.ProjectPeoples.Add(resource);
            dbContext.SaveChanges();

            return resource;
        }

        /// <summary>
        /// Get resource for project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>
        /// Returns all the list of resources for specified project
        /// </returns>
        public IEnumerable<ProjectPeople> Get(int projectId)
        {
            return dbContext.ProjectPeoples.Where(pp => pp.ProjectId == projectId);
        }

        /// <summary>
        /// Get resource details
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="personId"></param>
        /// <returns>
        /// Returns requested resource details
        /// </returns>
        public ProjectPeople GetResource(int projectId, int personId)
        {
            return dbContext.ProjectPeoples.FirstOrDefault(p => p.ProjectId == projectId && p.PeopleId == personId);
        }
    }
}
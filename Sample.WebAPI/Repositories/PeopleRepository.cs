using Sample.WebAPI.Models;
using System.Collections.Generic;

namespace Sample.WebAPI.Repositories
{
    /// <summary>
    /// People repository responsible for people entity database operations
    /// </summary>
    public class PeopleRepository : IPeopleRepository
    {
        private SampleDatabaseEntities dbContext = new SampleDatabaseEntities();

        /// <summary>
        /// Get people
        /// </summary>
        /// <returns>
        /// Returns all people
        /// </returns>
        public IEnumerable<Person> Get()
        {
            return dbContext.People;
        }

        /// <summary>
        /// Save person entity
        /// </summary>
        /// <param name="person"></param>
        /// <returns>
        /// Save and return person object
        /// </returns>
        public Person Add(Person person)
        {
            dbContext.People.Add(person);
            dbContext.SaveChanges();

            return person;
        }

    }
}
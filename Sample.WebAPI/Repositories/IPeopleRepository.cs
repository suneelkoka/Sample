using Sample.WebAPI.Models;
using System.Collections.Generic;

namespace Sample.WebAPI.Repositories
{
    /// <summary>
    /// People repository interface
    /// </summary>
    public interface IPeopleRepository
    {
        IEnumerable<Person> Get();
        Person Add(Person people);
    }
}

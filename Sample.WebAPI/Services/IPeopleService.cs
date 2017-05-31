using Sample.WebAPI.Models;
using Sample.WebAPI.ViewModels;
using System.Collections.Generic;

namespace Sample.WebAPI.Services
{
    /// <summary>
    /// Interface for People service
    /// </summary>
    public interface IPeopleService
    {
        ResponseModel<IEnumerable<PeopleModel>> Get();
        ResponseModel<PeopleModel> Add(Person people);
    }
}

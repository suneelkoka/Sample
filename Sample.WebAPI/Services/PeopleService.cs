using AutoMapper;
using Sample.WebAPI.Models;
using Sample.WebAPI.Repositories;
using Sample.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.WebAPI.Services
{
    /// <summary>
    /// PeopleService class is responsible for all People entty related logic
    /// which implements all IPeopleService methods 
    /// </summary>
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repository;

        /// <summary>
        /// PeopleService constructor
        /// </summary>
        /// <param name="repository"></param>
        public PeopleService(IPeopleRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get People 
        /// </summary>
        /// <returns>
        /// Returns list of People.
        /// </returns>
        public ResponseModel<IEnumerable<PeopleModel>> Get()
        {
            var result = new ResponseModel<IEnumerable<PeopleModel>>();
            try
            {
                var listObj = Mapper.Map<IEnumerable<Person>, IEnumerable<PeopleModel>>(_repository.Get());
                result = ResponseHelper.CreateSuccessResponse<IEnumerable<PeopleModel>>(listObj);
            }
            catch (Exception ex)
            {
                result = ResponseHelper.CreateFailureResponse<IEnumerable<PeopleModel>>(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Save People
        /// </summary>
        /// <param name="person">person obj which we need to save</param>
        /// <returns>
        /// Return saved person obj
        /// </returns>
        public ResponseModel<PeopleModel> Add(Person person)
        {
            var result = new ResponseModel<PeopleModel>();
            var message = string.Empty;
            try
            {
                if (!IsValid(person, out message))
                {
                    result = ResponseHelper.CreateFailureResponse<PeopleModel>(message);
                }
                else
                {
                    var newProject = Mapper.Map<Person, PeopleModel>(_repository.Add(person));
                    result = ResponseHelper.CreateSuccessResponse<PeopleModel>(newProject);
                }
            }
            catch (Exception ex)
            {
                result = ResponseHelper.CreateFailureResponse<PeopleModel>(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Validate the person obj
        /// </summary>
        /// <param name="person"></param>
        /// <param name="message">out parameter contains error messages</param>
        /// <returns>
        /// Returns true if valid else false
        /// </returns>
        private bool IsValid(Person person, out string message)
        {
            message = string.Empty;
            var people = _repository.Get();
            if (string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.FirstName))
            {
                message = "First Name/Last Name should not be empty.";
                return false;
            }
            if (people.Any(p => p.FirstName.ToLower() == person.FirstName.ToLower() && p.LastName.ToLower() == person.LastName.ToLower()))
            {
                message = "Person with same name is already existing.";
                return false;
            }

            return true;
        }
    }
}
using AutoMapper;
using Sample.WebAPI.Models;
using Sample.WebAPI.Repositories;
using Sample.WebAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace Sample.WebAPI.Services
{
    /// <summary>
    /// ResourceService class is responsible for all ProjectPeople entty related logic
    /// which implements all IResourceService methods 
    /// </summary>
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _repository;

        /// <summary>
        /// ResourceService constructor
        /// </summary>
        /// <param name="repository"></param>
        public ResourceService(IResourceRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Save resource
        /// </summary>
        /// <param name="resource"></param>
        /// <returns>
        /// Return saved resource obj
        /// </returns>
        public ResponseModel<ResourceModel> Add(ProjectPeople resource)
        {
            var result = new ResponseModel<ResourceModel>();
            var message = string.Empty;
            try
            {
                if (!IsValid(resource, out message))
                {
                    result = ResponseHelper.CreateFailureResponse<ResourceModel>(message);
                }
                else
                {
                    var newResource = Mapper.Map<ProjectPeople, ResourceModel>(_repository.Add(resource));
                    result = ResponseHelper.CreateSuccessResponse<ResourceModel>(newResource);
                }
            }
            catch (Exception ex)
            {
                result = ResponseHelper.CreateFailureResponse<ResourceModel>(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Get resources
        /// </summary>
        /// <param name="projectId">
        /// ProjectId for which resources are required
        /// </param>
        /// <returns>
        /// Return list of resources for project.
        /// </returns>
        public ResponseModel<IEnumerable<ResourceModel>> Get(int projectId)
        {
            var result = new ResponseModel<IEnumerable<ResourceModel>>();
            try
            {
                var listObj = Mapper.Map<IEnumerable<ProjectPeople>, IEnumerable<ResourceModel>>(_repository.Get(projectId));
                result = ResponseHelper.CreateSuccessResponse<IEnumerable<ResourceModel>>(listObj);
            }
            catch (Exception ex)
            {
                result = ResponseHelper.CreateFailureResponse<IEnumerable<ResourceModel>>(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Validate resource object
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="message">out parameter contains error messages</param>
        /// <returns>
        /// Returns true if valid else false
        /// </returns>
        private bool IsValid(ProjectPeople resource, out string message)
        {
            message = string.Empty;
            if (resource.ProjectId == 0 || resource.PeopleId == 0)
            {
                message = "Project/Resource should not be empty.";
                return false;
            }
            var dbResource = _repository.GetResource(resource.ProjectId, resource.PeopleId);
            if (dbResource != null)
            {
                message = "Resource is already existing in same project.";
                return false;
            }

            return true;
        }
    }
}
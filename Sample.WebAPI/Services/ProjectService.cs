using AutoMapper;
using Sample.WebAPI.Models;
using Sample.WebAPI.Repositories;
using Sample.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.WebAPI.Services
{
    /// <summary>
    /// ProjectService class is responsible for all project entty related logic
    /// </summary>
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        /// <summary>
        /// ProjectService constructor
        /// </summary>
        /// <param name="repository"></param>
        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get projects 
        /// </summary>
        /// <returns>
        /// Returns list of projects.
        /// </returns>
        public ResponseModel<IEnumerable<ProjectModel>> Get()
        {
            var result = new ResponseModel<IEnumerable<ProjectModel>>();
            try
            {
                var listObj = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectModel>>(_repository.Get());
                result = ResponseHelper.CreateSuccessResponse<IEnumerable<ProjectModel>>(listObj);
            }
            catch (Exception ex)
            {
                result = ResponseHelper.CreateFailureResponse<IEnumerable<ProjectModel>>(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Save project
        /// </summary>
        /// <param name="project">
        /// The project data which we need to save
        /// </param>
        /// <returns>
        /// Returns saved project object
        /// </returns>
        public ResponseModel<ProjectModel> Add(Project project)
        {
            var result = new ResponseModel<ProjectModel>();
            var message = string.Empty;
            try
            {
                if (!IsValid(project, out message))
                {
                    result = ResponseHelper.CreateFailureResponse<ProjectModel>(message);
                }
                else
                {
                    var newProject = Mapper.Map<Project, ProjectModel>(_repository.Add(project));
                    result = ResponseHelper.CreateSuccessResponse<ProjectModel>(newProject);
                }
            }
            catch (Exception ex)
            {
                result = ResponseHelper.CreateFailureResponse<ProjectModel>(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Validate the project obj
        /// </summary>
        /// <param name="project"></param>
        /// <param name="message">out parameter</param>
        /// <returns>
        /// Returns True if valid else false
        /// </returns>
        private bool IsValid(Project project, out string message)
        {
            message = string.Empty;
            var projects = _repository.Get();
            if (string.IsNullOrEmpty(project.Name))
            {
                message = "Project name should not be empty";
                return false;
            }
            if (projects.Any(p => p.Name.ToLower() == project.Name.ToLower()))
            {
                message = "Project with same name is already existing.";
                return false;
            }

            return true;
        }
    }
}
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using Sample.WebAPI.Filters;
using Sample.WebAPI.Helpers;
using Sample.WebAPI.Repositories;
using Sample.WebAPI.Resolver;
using Sample.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace Sample.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Register exception filter
            config.Filters.Add(new CustomExceptionFilter());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            //IOC Container
            var container = new UnityContainer();
            //Project entity
            container.RegisterType<IProjectService, ProjectService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProjectRepository, ProjectRepository>(new HierarchicalLifetimeManager());
            //People entity
            container.RegisterType<IPeopleService, PeopleService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPeopleRepository, PeopleRepository>(new HierarchicalLifetimeManager());
            //Project People entity
            container.RegisterType<IResourceService, ResourceService>(new HierarchicalLifetimeManager());
            container.RegisterType<IResourceRepository, ResourceRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //To Enable CORS
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

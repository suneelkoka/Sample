using AutoMapper;
using Sample.WebAPI.Models;
using Sample.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.WebAPI.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Project, ProjectModel>().ReverseMap();
                config.CreateMap<Person, PeopleModel>().ReverseMap();
                config.CreateMap<ProjectPeople, ResourceModel>().ReverseMap();
            });
        }
    }
}
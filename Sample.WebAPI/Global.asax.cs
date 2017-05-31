using Sample.WebAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Sample.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Intialize AutoMapper
            AutoMapperConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //HttpConfiguration config = GlobalConfiguration.Configuration;

            //config.Formatters.JsonFormatter
            //            .SerializerSettings
            //            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}

using Sample.WebAPI.Models;
using Sample.WebAPI.Services;
using System.Web.Http;

namespace Sample.WebAPI.Controllers
{
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {
        IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_service.Get());
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]Project project )
        {
            if (project == null) return BadRequest();
            return Ok(_service.Add(project));
            //return Ok();
        }
    }
}

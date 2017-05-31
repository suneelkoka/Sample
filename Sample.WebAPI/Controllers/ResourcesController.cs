using Sample.WebAPI.Models;
using Sample.WebAPI.Services;
using System.Web.Http;

namespace Sample.WebAPI.Controllers
{
    [RoutePrefix("api/resources")]
    public class ResourcesController : ApiController
    {
        private readonly IResourceService _service;

        public ResourcesController(IResourceService service)
        {
            _service = service;
        }

        [Route("{projectId:int}")]
        public IHttpActionResult Get(int projectId)
        {
            if (projectId == 0) return BadRequest();
            return Ok(_service.Get(projectId));
        }

        [Route("~/api/resource")]
        public IHttpActionResult Post([FromBody]ProjectPeople resource)
        {
            if (resource == null) return BadRequest();
            return Ok(_service.Add(resource));
        }
    }
}

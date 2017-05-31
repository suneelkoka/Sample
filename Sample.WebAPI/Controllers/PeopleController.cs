using Sample.WebAPI.Models;
using Sample.WebAPI.Services;
using System.Web.Http;

namespace Sample.WebAPI.Controllers
{
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        private readonly IPeopleService _service;

        public PeopleController(IPeopleService service)
        {
            _service = service;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_service.Get());
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_service.Add(person));
        }
    }
}

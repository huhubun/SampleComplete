using System;
using System.Web.Http;

namespace ReturnCustomErrorResponse.Controllers
{
    public class TodoController : ApiController
    {
        [Route("api/Todos")]
        public IHttpActionResult Get()
        {
            throw new NotImplementedException("Not Implement", new Exception("Just a test"));
        }
    }
}
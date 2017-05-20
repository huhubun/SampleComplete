using OwinSelfHostLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OwinSelfHostLogging.Controller
{
    public class TodoController : ApiController
    {
        private static List<TodoModel> todoList = Enumerable.Range(1, 1).Select(i => new TodoModel { Id = i, Title = $"todo item: {i}" }).ToList();

        [Route("api/Todos")]
        public IHttpActionResult Get()
        {
            return Ok(todoList);
        }

        [Route("api/Todos")]
        public IHttpActionResult Post(TodoModel request)
        {
            todoList.Add(request);

            return Ok(todoList);
        }
    }
}

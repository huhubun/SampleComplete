using PagingByLinkHeader.ActionResults;
using PagingByLinkHeader.Models;
using PagingByLinkHeader.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace PagingByLinkHeader.Controllers
{
    public class TodoController : ApiController
    {
        private readonly IEnumerable<TodoModel> todoList = Enumerable.Range(1, 20).Select(i => new TodoModel { Id = i, Title = $"todo item: {i}" });

        [Route("api/Todos", Name = "GetTodos")]
        public IHttpActionResult Get(string keyword = null, int page = 1, int pageSize = 5)
        {
            var data = todoList;
            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(d => d.Title.Contains(keyword));
            }

            var total = todoList.Count();
            var skip = (page - 1) * pageSize;

            data = data.Skip(skip).Take(pageSize);

            if (data.Count() == 0)
            {
                return NotFound();
            }

            var pagingLinkBuilder = new PagingLinkBuilder<IEnumerable<TodoModel>>(Url, "GetTodos", data, page, pageSize, total);
            return Ok(pagingLinkBuilder);
        }

        private IHttpActionResult Ok<T>(PagingLinkBuilder<T> data)
        {
            return new PagingResult<T>(data, Request);
        }
    }
}
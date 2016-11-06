using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

using WebAdmin.Infrastructure.Helpers;
using WebAdmin.Infrastructure.Repositories;

namespace WebAdmin.API.Controllers
{
    [Route("[controller]")]
    public class Users : Controller
    {
        private readonly IUserRepository repository;

        const int MaxPageSize = 100;

        public Users(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get(string sort = "UserID", string name = null, byte? statusID = null, int page = 1, int pageSize = MaxPageSize)
        {
            try
            {
                var users = repository.GetUsers()
                    .ApplySort(sort)
                    .Where(u => (name == null || u.FullName.Contains(name)))
                    .Where(u => (statusID == null || u.UserStatusID == statusID));

                if (pageSize > MaxPageSize) pageSize = MaxPageSize;

                // Calculate data for metadata
                var totalCount = users.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(ControllerContext);
                var prevLink = page > 1 ? urlHelper.Action("Get",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        sort = sort,
                        name = name,
                        statusID = statusID
                    }) : "";

                var nextLink = page < totalPages ? urlHelper.Action("Get",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        sort = sort,
                        name = name,
                        statusID = statusID
                    }) : "";


                var paginationHeader = new
                {
                    currentPage = page,
                    pageSize = pageSize,
                    totalCount = totalCount,
                    totalPages = totalPages,
                    previousPageLink = prevLink,
                    nextPageLink = nextLink
                };

                HttpContext.Response.Headers.Add("X-Pagination",
                   Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

                return Ok(users
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize)
                    .ToList());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await repository.GetUser(id);

                if (user == null)
                    return NotFound();
                else
                    return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
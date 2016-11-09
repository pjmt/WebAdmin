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
    public class Organisations : Controller
    {
        const int MaxPageSize = 100;

        protected readonly IOrganisationRepository repository;

        public Organisations(IOrganisationRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get(string sort = "OrganisationID", string name = null, byte? statusID = null, int page = 1, int pageSize = MaxPageSize)
        {
            try
            {
                var organisations = repository.GetOrganisations()
                    .ApplySort(sort)
                    .Where(o => (name == null || o.OrganisationName.Contains(name)))
                    .Where(o => (statusID == null || o.OrganisationStatusID == statusID));

                if (pageSize > MaxPageSize) pageSize = MaxPageSize;

                // calculate data for metadata
                var totalCount = organisations.Count();
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

                return Ok(organisations
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
                var organisation = await repository.GetOrganisationAsync(id);

                if (organisation == null)
                    return NotFound();
                else
                    return Ok(organisation);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{parentOrganisationID}/children")]
        public IActionResult GetChildren(int parentOrganisationID)
        {
            try
            {
                var organisations = repository.GetChildOrganisations(parentOrganisationID);

                if (!organisations.Any())
                {
                    return NotFound();
                }

                return Ok(organisations.ToList());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

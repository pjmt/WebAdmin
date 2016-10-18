using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var organisation = repository.GetOrganisation(id);

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
    }
}

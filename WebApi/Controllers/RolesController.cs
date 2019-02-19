using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestowaApkaAndea.Models;
using TestowaApkaAndea.Repository;

namespace TestowaApkaAndea.Controllers
{
    public class RolesController : BaseController
    {
        private readonly IRepository repository;

        public RolesController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET api/roles
        [HttpGet]
        public ActionResult<IEnumerable<Role>> Get()
        {
            try
            {
                var roles = repository.GetRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/roles/5
        [HttpGet("{id}")]
        public ActionResult<Role> Get(int id)
        {
            try
            {
                var role = repository.GetRole(id);

                if (role == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(role);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
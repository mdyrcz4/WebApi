using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestowaApkaAndea.Models;
using TestowaApkaAndea.Repository;

namespace TestowaApkaAndea.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IRepository repository;

        public UsersController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                var users = repository.GetUsers();
                return Ok(users);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                var user = repository.GetUser(id);

                if(user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid user object");
                }
                var dbUser = repository.GetUser(id);
                if (dbUser == null)
                {
                    return NotFound();
                }
                else
                {
                    var role = repository.GetRole(user.RoleId);
                    if(role == null)
                    {
                        return BadRequest("Invalid role id");
                    }
                    else
                    {
                        repository.UpdateUser(dbUser, user);
                        return Ok("Updated");
                    }
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Api.Controllers
{
    


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User value)
        {
            var user = new User {
                UserId = id,
                FirstName = "Jimmy",
                LastName = "Fred",
                Street = value.Street,
                City = value.City,
                State = value.State,
                Zip = value.Zip,
                Admin = value.Admin
                };

            return user;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

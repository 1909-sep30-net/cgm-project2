﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Library.Repositories;
using Logic.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.Library.Interfaces;

namespace Rest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository repo;

        /// <summary>
        /// This is the constructor for the UseController Class.
        /// </summary>
        /// <param name="context"></param>
        public UserController(IUserRepository context)
        {
            this.repo = context ?? throw new ArgumentNullException(nameof(repo));
        }


        /// <summary>
        /// This method searches the Db for all the users and returns a List<User>
        /// </summary>
        /// <returns></returns>
        // GET: api/User
        [HttpGet]
        public List<User> Get()
        {
            var users = repo.SearchUsers().ToList();
            repo.Save();
            return users;
            //return "temp success";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/User
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
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

            repo.RegisterNewUser(user);
            repo.Save();
            //return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

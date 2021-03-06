﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Library.Repositories;
using Logic.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.Library.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Rest.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class TakeAQuizController : ControllerBase
    {
        ITakeAQuizRepository repo;

        public TakeAQuizController(ITakeAQuizRepository context)
        {
            this.repo = context ?? throw new ArgumentNullException(nameof(repo));
        }
        /*********************************************************************/

        // GET: api/TakeAQuiz => this gets all the quiz titles
        [HttpGet]
        public IEnumerable<Title> Get()
        {
            return repo.GetQuizByNameOrId();
        }

        // GET: api/TakeAQuiz/5 => this uses the quiz Id to get a chosen quiz to take
        [HttpGet("{id}")]
        public Quiz Get(int id)
        {
            //query DB for the quiz by it's Id.
            Quiz quiz = repo.GetQuiz(id);
            return quiz;
        }

        // GET: api/TakeAQuiz/5 => this will get the last quiz taken with that titleId
        [HttpGet("getresult/{id}")]
        public Category GetResult(int id)
        {
            //query DB for the category acheived by the final quiz of that type take.
            return repo.GetLastQuizBytitleId(id);
        }

        //// GET: api/TakeAQuiz/my quiz => this uses the quiz title to get a chosen quiz to take
        //[HttpGet("{title}", Name = "GetTakeAQuiz1")]
        //public Quiz Get(string title)
        //{
        //    //query DB for the quiz by it's Id.
        //    return repo.GetQuiz(title:title);
        //}

        // POST: api/TakeAQuiz

        [HttpPost]//this needs to accept an array.
        public ActionResult Post([FromBody] int[] list)
        {
            repo.EvaluateQuiz(list);//EvaluateQuiz returned a category.
            repo.Save();
            return StatusCode(StatusCodes.Status202Accepted);
        }

        // PUT: api/TakeAQuiz/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        { }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        { }
    }
}

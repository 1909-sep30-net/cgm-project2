using System;
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
    [ApiController]
    public class ResultController : ControllerBase
    {
        IResultRepository repo;

        public ResultController(IResultRepository context)
        {
            this.repo = context ?? throw new ArgumentNullException(nameof(repo));
        }


        // GET: api/Result
        [HttpGet]
        public List<Result> Get()
        {
            return repo.GetResults().ToList();
        }

        // GET: api/Result/5
        [HttpGet("{id}", Name = "ResultGet")]
        public List<Result> Get(int id)
        {
            return repo.GetResults(id).ToList();
        }

        //// POST: api/Result
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Result/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

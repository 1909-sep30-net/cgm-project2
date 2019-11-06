using System;
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
    public class TakeAQuizController : ControllerBase
    {
        ITakeAQuizRepository repo;

        public TakeAQuizController(ITakeAQuizRepository context)
        {
            this.repo = context ?? throw new ArgumentNullException(nameof(repo));
        }



        // GET: api/TakeAQuiz
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TakeAQuiz/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TakeAQuiz
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TakeAQuiz/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

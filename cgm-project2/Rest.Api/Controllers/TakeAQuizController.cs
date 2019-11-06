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
        public IEnumerable<Title> Get()
        {
            return repo.GetQuizByNameOrId();
        }

        // GET: api/TakeAQuiz/5
        [HttpGet("{id}", Name = "Get")]
        public Quiz Get(int id)
        {
            return repo.GetQuiz(id);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Library.Repositories;
using Logic.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.Library.Interfaces;
using Microsoft.EntityFrameworkCore;

using DatLib = Data.Library;

namespace Rest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateQuizController : ControllerBase
    {
        ICreateQuizRepository repo;

        Models.CreateQuizIds ids = new Models.CreateQuizIds();

        
        public CreateQuizController(ICreateQuizRepository context)
        {
            this.repo = context ?? throw new ArgumentNullException(nameof(repo));
        }


        // GET: api/CreateQuiz
        [HttpGet]
        public Title Get()
        {
            return repo.GetTitle();
        }

        // POST: api/CreateQuiz/Title
        [HttpPost("Title")]
        public void PostTitle([FromBody, Bind("titleString, creatorId")] Models.TitleModel title)
        {
            repo.CreateTitle(new Title { TitleString = title.TitleString, CreatorId = title.CreatorId });
            repo.Save();
            ids.CreatorId = title.CreatorId;
        }

    }
}

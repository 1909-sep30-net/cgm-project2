﻿using System;
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
using Microsoft.AspNetCore.Authorization;

namespace Rest.Api.Controllers
{
    /// <summary>
    /// A controller with Functionality for Creating a Quiz with HTTP Req/Res 
    /// </summary>
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class CreateQuizController : ControllerBase
    {
        /// <summary>
        /// Repository with main Create Quiz methods
        /// </summary>
        ICreateQuizRepository repo;

        /// <summary>
        /// Repository with helper methods
        /// </summary>
        IGetDataRepository getRepo;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">database connection</param>
        /// <param name="getContext">database connection</param>
        public CreateQuizController(ICreateQuizRepository context, IGetDataRepository getContext)
        {
            this.repo = context ?? throw new ArgumentNullException(nameof(repo));
            this.getRepo = getContext ?? throw new ArgumentNullException(nameof(repo));
        }

        //TODO:Implement functionality or remove method
        // GET: api/CreateQuiz
        [HttpGet]
        public ActionResult Get()
        {
            return StatusCode(StatusCodes.Status100Continue);
        }

        //TODO:Implement functionality or remove method
        // GET: api/CreateQuiz/LastTitleBy/{id}
        [HttpGet("LastTitleBy/{id}")]
        public int GetNewTitleId(int id)
        {
            return getRepo.GetLastTitleId(id);
        }

        [HttpGet("LastQuestionByTitle/{id}")]
        public int GetNewQuestionId(int id)
        {
            return getRepo.GetLastQuestionId(id);
        }

        [HttpGet("LastCategoryByTitle/{id}")]
        public int GetNewCategoryId(int id)
        {
            return getRepo.GetLastCategoryId(id);
        }
        
        [HttpGet("NumberOfQuestions/{id}")]
        public int GetNumberOfQuestions(int id)
        {
            return getRepo.GetNumberOfQuestions(id);
        }



        // POST: api/CreateQuiz/Title
        [HttpPost("Title")]
        public ActionResult PostTitle([FromBody, Bind("titleString, creatorId")] Models.TitleModel title)
        {
            if (!getRepo.UserExists(title.CreatorId))
                return StatusCode(StatusCodes.Status406NotAcceptable);
            repo.CreateTitle(new Title { TitleString = title.TitleString, CreatorId = title.CreatorId });
            repo.Save();
            return StatusCode(StatusCodes.Status202Accepted);
        }

        // POST: api/CreateQuiz/Category
        [HttpPost("Category")]
        public ActionResult PostCategory([FromBody, Bind("categoryString, categoryDescription, titleId")] Models.CategoryModel category)
        {
            if (! getRepo.TitleExists(category.TitleId))
                return StatusCode(StatusCodes.Status406NotAcceptable);

            repo.CreateCategory(new Category
            {
                CategoryString = category.CategoryString,
                CategoryDescription = category.CategoryDescription,
                TitleId = category.TitleId,
                Rank = getRepo.GetNumberOfCategories(category.TitleId) + 1
            });
            repo.Save();
            return StatusCode(StatusCodes.Status202Accepted);
        }

        // Put: api/CreateQuiz/Category/Ranks
        [HttpPut("Category/Ranks")]
        public ActionResult PutCategoryRanks([FromBody, Bind("categoryId, rank")] Models.CategoryModel[] categories)
        {
            int maxRank = categories.Length;
            var ranks = new HashSet<int> { };
            for (int i = 0; i < maxRank; i++)
            {
                int rank = categories[i].Rank;
                if (rank < 0 || rank > maxRank || ranks.Contains(rank))
                    return StatusCode(StatusCodes.Status406NotAcceptable);
                ranks.Add(rank);
            }

            foreach (var category in categories)
            {
                repo.SetCategoryRank(category.CategoryId, category.Rank);
            }
            repo.Save();
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // POST: api/CreateQuiz/Question
        [HttpPost("Question")]
        public ActionResult PostQuestion([FromBody, Bind("titleId, questionString")] Models.QuestionModel question)
        {
            if (! getRepo.TitleExists(question.TitleId))
                return StatusCode(StatusCodes.Status406NotAcceptable);
            repo.CreateQuestion(new Question
            {
                TitleId = question.TitleId,
                QuestionString = question.QuestionString
            });
            repo.Save();
            return StatusCode(StatusCodes.Status202Accepted);
        }

        // POST: api/CreateQuiz/Answer
        [HttpPost("Answer")]
        public ActionResult PostAnswer([FromBody, Bind("questionId, categoryId, answerString, weight")] Models.AnswerModel answer)
        {
            if (! getRepo.QuestionExists(answer.QuestionId) || ! getRepo.CategoryExists(answer.CategoryId))
                return StatusCode(StatusCodes.Status406NotAcceptable);
            repo.CreateAnswer(new Answer
            {
                QuestionId = answer.QuestionId,
                CategoryId = answer.CategoryId,
                AnswerString = answer.AnswerString,
                Weight = answer.Weight
            }) ;
            repo.Save();
            return StatusCode(StatusCodes.Status202Accepted);
        }

        // GET: api/CreateQuiz/Answer/id
        [HttpGet("Answer/{id}")]
        public List<Answer> GetAnswers(int id)
        {
            var users = getRepo.GetAnswers(id).ToList();
            //repo.Save();
            return users;
            //return "temp success";
        }

    }
}

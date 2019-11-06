using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DatLib = Data.Library;
using LogLib = Logic.Library;
using Logic.Library.Interfaces;

namespace Data.Library.Repositories
{
    /// <summary>
    /// A Repository for Database manipulation when creating a quiz
    /// </summary>
    public class CreateQuizRepository : ICreateQuizRepository
    {
        /// <summary>
        /// Database Connection
        /// </summary>
        private readonly Entities.ecgbhozpContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Database Connection</param>
        public CreateQuizRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// Adds a new title to the database
        /// </summary>
        /// <param name="title">A Logic.Library.Model Title</param>
        public void CreateTitle(LogLib.Models.Title title)
        {
            var titleEnt = Mapper.MapTitle(title);
            titleEnt.TitleId = 0;
            _dbContext.Title.Add(titleEnt);
        }

        /// <summary>
        /// Adds a new category to the database 
        /// </summary>
        /// <param name="category">A Logic.Library.Model Category</param>
        public void CreateCategory(LogLib.Models.Category category)
        {
            var categoryEnt = Mapper.MapCategory(category);
            categoryEnt.CategoryId = 0;
            _dbContext.Category.Add(categoryEnt);
        }

        /// <summary>
        /// Adds a new question to the database
        /// </summary>
        /// <param name="question">A Logic.Library.Model Question</param>
        public void CreateQuestion(LogLib.Models.Question question)
        {
            var questionEnt = Mapper.MapQuestion(question);
            questionEnt.QuestionId = 0;
            _dbContext.Question.Add(questionEnt);
        }

        /// <summary>
        /// Adds a new answer to the database
        /// </summary>
        /// <param name="answer">A Logic.Library.Model Answer</param>
        public void CreateAnswer(LogLib.Models.Answer answer)
        {
            var answerEnt = Mapper.MapAnswer(answer);
            answerEnt.AnswerId = 0;
            _dbContext.Answer.Add(answerEnt);
        }

        /// <summary>
        /// Delete a Title, and cascade delete it's children
        /// </summary>
        /// <param name="titleId">A Id of a title in the database</param>
        public void DeleteQuiz(int titleId)
        {
            _dbContext.Title.Remove(_dbContext.Title.Find(titleId));
        }

        /// <summary>
        /// Sets the rank of a category
        /// </summary>
        /// <param name="categoryId">The Id of a category in the database</param>
        /// <param name="newRank">The rank to be set</param>
        public void SetCategoryRank(int categoryId, int newRank)
        {
            _dbContext.Category.Find(categoryId).Rank = newRank;
        }

        /// <summary>
        /// Save the state of the repo context
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

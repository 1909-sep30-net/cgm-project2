using System;
using System.Collections.Generic;
using System.Text;
using LogLibMod = Logic.Library.Models;

namespace Logic.Library.Interfaces
{
    public interface ICreateQuizRepository
    {
        /// <summary>
        /// Adds a new title to the database
        /// </summary>
        /// <param name="title">A Logic.Library.Model Title</param>
        public void CreateTitle(LogLibMod.Title title);

        /// <summary>
        /// Adds a new category to the database 
        /// </summary>
        /// <param name="category">A Logic.Library.Model Category</param>
        public void CreateCategory(LogLibMod.Category category);

        /// <summary>
        /// Adds a new question to the database
        /// </summary>
        /// <param name="question">A Logic.Library.Model Question</param>
        public void CreateQuestion(LogLibMod.Question question);

        /// <summary>
        /// Adds a new answer to the database
        /// </summary>
        /// <param name="answer">A Logic.Library.Model Answer</param>
        public void CreateAnswer(LogLibMod.Answer answer);

        /// <summary>
        /// Delete a Title, and cascade delete it's children
        /// </summary>
        /// <param name="titleId">A Id of a title in the database</param>
        public void DeleteQuiz(int titleId);

        /// <summary>
        /// Sets the rank of a category
        /// </summary>
        /// <param name="categoryId">The Id of a category in the database</param>
        /// <param name="newRank">The rank to be set</param>
        public void SetCategoryRank(int categoryId, int newRank);

        /// <summary>
        /// Save the state of the repo context
        /// </summary>
        public void Save();
    }
}

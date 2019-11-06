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
    /// A repo with helper methods regarding the database
    /// </summary>
    public class GetDataRepository : IGetDataRepository
    {
        /// <summary>
        /// Database Connection
        /// </summary>
        private readonly Entities.ecgbhozpContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Database Connection</param>
        public GetDataRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// Checks if a User in the database exists
        /// </summary>
        /// <param name="userId">The id of a User to check</param>
        /// <returns>true if User exists, else false</returns>
        public bool UserExists(int userId)
        {
            return _dbContext.User.Find(userId) != null;
        }

        /// <summary>
        /// Checks if a Title in the database exists
        /// </summary>
        /// <param name="titleId">The id of a Title to check</param>
        /// <returns>true if Title exists, else false</returns>
        public bool TitleExists(int titleId)
        {
            return _dbContext.Title.Find(titleId) != null;
        }

        /// <summary>
        /// Checks if a Category in the database exists
        /// </summary>
        /// <param name="categoryId">The id of a category to check</param>
        /// <returns>true if Category exists, else false</returns>
        public bool CategoryExists(int categoryId)
        {
            return _dbContext.Category.Find(categoryId) != null;
        }

        /// <summary>
        /// Checks if a Question in the database exists
        /// </summary>
        /// <param name="questionId">The id of a Question to check</param>
        /// <returns>true if Question exists, else false</returns>
        public bool QuestionExists(int questionId)
        {
            return _dbContext.Question.Find(questionId) != null;
        }

        /// <summary>
        /// Gets the id of the last title created by a user
        /// </summary>
        /// <param name="creatorId">the id of the user who may have created a title</param>
        /// <returns>the titleId if it exists, else -1 </returns>
        public int GetLastTitleId(int creatorId)
        {
            try
            {
                return _dbContext.Title.Where(t => t.CreatorId == creatorId).ToList().LastOrDefault().TitleId;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// The the current number of categories of a title
        /// </summary>
        /// <param name="titleId">The Id of a title in the db</param>
        /// <returns>The number of categories</returns>
        public int GetNumberOfCategories(int titleId)
        {
            return _dbContext.Category.Where(c => c.TitleId == titleId).Count();
        }

    }
}

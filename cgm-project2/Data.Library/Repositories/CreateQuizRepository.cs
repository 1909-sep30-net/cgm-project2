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
    public class CreateQuizRepository
    {
        private readonly Entities.ecgbhozpContext _dbContext;
        public CreateQuizRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public LogLib.Models.Title CreateTitle(int titleId, string titleString, int creatorId)
        {
            return new LogLib.Models.Title
            {
                TitleId = titleId,
                TitleString = titleString,
                CreatorId = creatorId
            };
        }

        public LogLib.Models.Category CreateCategory(int categoryId, string categoryString, string categoryDescription, int titleId)
        {
            return new LogLib.Models.Category
            {
                CategoryId = categoryId,
                CategoryString = categoryString,
                CategoryDescription = categoryDescription,
                TitleId = titleId
            };
        }

        public LogLib.Models.Question CreateQuestion(int questionId, string questionString, int titleId)
        {
            return new LogLib.Models.Question
            {
                QuestionId = questionId,
                QuestionString = questionString,
                TitleId = titleId
            };
        }

        public LogLib.Models.Answer CreateAnswer(int answerId, string answerString, int weight, int categoryId, int questionId)
        {
            return new LogLib.Models.Answer
            {
                AnswerId = answerId,
                AnswerString = answerString,
                Weight = weight,
                CategoryId = categoryId,
                QuestionId = questionId
            };
        }

    }
}

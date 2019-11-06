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
    public class CreateQuizRepository : ICreateQuizRepository
    {
        private readonly Entities.ecgbhozpContext _dbContext;
        public CreateQuizRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public void CreateTitle(LogLib.Models.Title title)
        {
            var titleEnt = Mapper.MapTitle(title);
            titleEnt.TitleId = 0;
            _dbContext.Title.Add(titleEnt);
        }

        public void CreateCategory(LogLib.Models.Category category)
        {
            var categoryEnt = Mapper.MapCategory(category);
            categoryEnt.CategoryId = 0;
            _dbContext.Category.Add(categoryEnt);
        }

        public void CreateQuestion(LogLib.Models.Question question)
        {
            var questionEnt = Mapper.MapQuestion(question);
            questionEnt.QuestionId = 0;
            _dbContext.Question.Add(questionEnt);
        }

        public void CreateAnswer(LogLib.Models.Answer answer)
        {
            var answerEnt = Mapper.MapAnswer(answer);
            answerEnt.AnswerId = 0;
            _dbContext.Answer.Add(answerEnt);
        }

        public void DeleteQuiz(int titleId)
        {
            _dbContext.Title.Remove(_dbContext.Title.Find(titleId));
        }

        public void SetCategoryRank(int categoryId, int newRank)
        {
            _dbContext.Category.Find(categoryId).Rank = newRank;
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }


        //REMOVE THIS BEFORE MERGE
        public IEnumerable<LogLib.Models.Title> GetTitle()
        {
            return _dbContext.Title.Select(Mapper.MapTitle);
        }
    }
}

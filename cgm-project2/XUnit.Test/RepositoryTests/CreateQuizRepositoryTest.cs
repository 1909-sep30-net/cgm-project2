using System;
using System.Collections.Generic;
using DatLib = Data.Library;
using Microsoft.EntityFrameworkCore;
using Xunit;
using LogLib = Logic.Library;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;

using Data.Library.Repositories;
using LogLibMod = Logic.Library.Models;

namespace XUnit.Test
{
    public class CreateQuizRepositoryTest
    {
        [Fact]
        public void CreateTitleCreatesTitle()
        {
            //arrange

            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("SearchUsersReturnsAllCustomers")
                .Options;

            int titleId = 1;
            string titleString = "TitleString";
            int creatorId = 1;

            var titleLog = new LogLibMod.Title() { TitleId = titleId, TitleString = titleString, CreatorId = creatorId };

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            var repo = new CreateQuizRepository(actContext);

            //act
            repo.CreateTitle(titleLog);
            repo.Save();

            using var assertContext = new DatLib.Entities.ecgbhozpContext(options);
            var title = assertContext.Title.FirstOrDefault();
            //assert

            Assert.Equal(expected: titleId + titleString + creatorId, actual: title.TitleId + title.TitleString + title.CreatorId);
        }


        [Fact]
        public void CreateCategoryCreatesCategory()
        {
            //arrange

            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("CreateCategoryCreatesCategory")
                .Options;

            int categoryId = 1;
            string categoryString = "CategoryString";
            string categoryDescription = "Desc";
            int titleId = 1;

            var categoryLog = new LogLibMod.Category { CategoryId = categoryId, CategoryString = categoryString, CategoryDescription = categoryDescription, TitleId = titleId };

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            var repo = new CreateQuizRepository(actContext);

            //act
            repo.CreateCategory(categoryLog);
            repo.Save();

            using var assertContext = new DatLib.Entities.ecgbhozpContext(options);
            var category = assertContext.Category.FirstOrDefault();
            //assert

            Assert.Equal(expected: categoryId + categoryString + categoryDescription + titleId, actual: category.CategoryId + category.CategoryString + category.CategoryDescription + category.TitleId);
        }

        [Fact]
        public void CreateQuestionCreatesQuestion()
        {
            //arrange

            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("CreateQuestionCreatesQuestion")
                .Options;

            int questionId = 1;
            string questionString = "This is Question?";
            int titleId = 1;

            var questionLog = new LogLibMod.Question { QuestionId = questionId, QuestionString = questionString, TitleId = titleId };

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            var repo = new CreateQuizRepository(actContext);

            //act
            repo.CreateQuestion(questionLog);
            repo.Save();

            using var assertContext = new DatLib.Entities.ecgbhozpContext(options);
            var question = assertContext.Question.FirstOrDefault();
            //assert

            Assert.Equal(expected: questionId + questionString + titleId, actual: question.QuestionId + question.QuestionString + question.TitleId);
        }

        [Fact]
        public void CreateAnswerCreatesAnswer()
        {
            //arrange

            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("CreateAnswerCreatesAnswer")
                .Options;

            int answerId = 1;
            string answerString = "Answer String";
            int weight = 1;
            int categoryId = 1;
            int questionId = 1;

            var answerLog = new LogLibMod.Answer { AnswerId = answerId, AnswerString = answerString, Weight = weight, CategoryId = categoryId, QuestionId = questionId };

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            var repo = new CreateQuizRepository(actContext);

            //act
            repo.CreateAnswer(answerLog);
            repo.Save();

            using var assertContext = new DatLib.Entities.ecgbhozpContext(options);
            var answer = assertContext.Answer.FirstOrDefault();
            //assert

            Assert.Equal(expected: answerId + answerString + weight + categoryId + questionId, actual: answer.AnswerId + answer.AnswerString + answer.Weight + answer.CategoryId + answer.QuestionId);
        }

    }
}

using System;
using System.Collections.Generic;
using DatLib = Data.Library;
using Microsoft.EntityFrameworkCore;
using Xunit;
using LogLib = Logic.Library;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;

using Data.Library.Repositories;

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

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            var repo = new CreateQuizRepository(actContext);

            //act
            var title = repo.CreateTitle(titleId, titleString, creatorId);

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

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            var repo = new CreateQuizRepository(actContext);

            //act
            var category = repo.CreateCategory( categoryId,  categoryString,  categoryDescription,  titleId);

            //assert

            Assert.Equal(expected:  categoryId+  categoryString+ categoryDescription+  titleId, actual: category.CategoryId + category.CategoryString + category.CategoryDescription + category.TitleId);
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

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            var repo = new CreateQuizRepository(actContext);

            //act
            var question = repo.CreateQuestion(questionId, questionString, titleId);

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

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            var repo = new CreateQuizRepository(actContext);

            //act
            var answer = repo.CreateAnswer(answerId,  answerString,  weight,  categoryId,  questionId);

            //assert

            Assert.Equal(expected: answerId+ answerString+ weight+ categoryId+ questionId, actual: answer.AnswerId + answer.AnswerString + answer.Weight + answer.CategoryId + answer.QuestionId);
        }
    }
}

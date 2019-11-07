using Microsoft.EntityFrameworkCore;
using Xunit;
using LogLib = Logic.Library;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;
using Moq;
using Data.Library.Repositories;
using LogLibMod = Logic.Library.Models;
using System.Collections;
using System.Collections.Generic;
using Rest.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace XUnit.Test.ControllerTests
{
    public class CreateQuizControllerTests
    {

        [Fact]
        public void PostCategorySucceeds()
        {
            //arrange
            var mockRepo = new Mock<LogLib.Interfaces.ICreateQuizRepository>();
            mockRepo.Setup(r => r.CreateCategory(It.IsAny<LogLibMod.Category>()));

            var mockGetRepo = new Mock<LogLib.Interfaces.IGetDataRepository>();
            mockGetRepo.Setup(r => r.TitleExists(It.IsAny<int>())).Returns(true);

            var controller = new CreateQuizController(mockRepo.Object, mockGetRepo.Object);

            //act assert
            var statusCode = Assert.IsType<StatusCodeResult>(controller.PostCategory(new Rest.Api.Models.CategoryModel { }));
            Assert.Equal(202, statusCode.StatusCode);
        }

        [Fact]
        public void PostQuestionSucceeds()
        {
            //arrange
            var mockRepo = new Mock<LogLib.Interfaces.ICreateQuizRepository>();
            mockRepo.Setup(r => r.CreateQuestion(It.IsAny<LogLibMod.Question>()));

            var mockGetRepo = new Mock<LogLib.Interfaces.IGetDataRepository>();
            mockGetRepo.Setup(r => r.TitleExists(It.IsAny<int>())).Returns(true);

            var controller = new CreateQuizController(mockRepo.Object, mockGetRepo.Object);

            //act assert
            var statusCode = Assert.IsType<StatusCodeResult>(controller.PostQuestion(new Rest.Api.Models.QuestionModel { }));
            Assert.Equal(202, statusCode.StatusCode);
        }

        [Fact]
        public void PostAnswerSucceeds()
        {
            //arrange
            var mockRepo = new Mock<LogLib.Interfaces.ICreateQuizRepository>();
            mockRepo.Setup(r => r.CreateAnswer(It.IsAny<LogLibMod.Answer>()));

            var mockGetRepo = new Mock<LogLib.Interfaces.IGetDataRepository>();
            mockGetRepo.Setup(r => r.QuestionExists(It.IsAny<int>())).Returns(true);
            mockGetRepo.Setup(r => r.CategoryExists(It.IsAny<int>())).Returns(true);

            var controller = new CreateQuizController(mockRepo.Object, mockGetRepo.Object);

            //act assert
            var statusCode = Assert.IsType<StatusCodeResult>(controller.PostAnswer(new Rest.Api.Models.AnswerModel { }));
            Assert.Equal(202, statusCode.StatusCode);
        }

        [Fact]
        public void PutRanksPassesCorrectly()
        {
            //arrange
            var mockRepo = new Mock<LogLib.Interfaces.ICreateQuizRepository>();
            mockRepo.Setup(r => r.SetCategoryRank(It.IsAny<int>(), It.IsAny<int>()));

            var mockGetRepo = new Mock<LogLib.Interfaces.IGetDataRepository>();

            var controller = new CreateQuizController(mockRepo.Object, mockGetRepo.Object);

            var categories = new Rest.Api.Models.CategoryModel[1]
            {
                new Rest.Api.Models.CategoryModel
                {
                    Rank = 1
                }
            };

            //act assert
            var statusCode = Assert.IsType<StatusCodeResult>(controller.PutCategoryRanks(categories));
            Assert.Equal(204, statusCode.StatusCode);
        }

        [Fact]
        public void PutRanksFailsCorrectly()
        {
            //arrange
            var mockRepo = new Mock<LogLib.Interfaces.ICreateQuizRepository>();
            mockRepo.Setup(r => r.SetCategoryRank(It.IsAny<int>(), It.IsAny<int>()));

            var mockGetRepo = new Mock<LogLib.Interfaces.IGetDataRepository>();

            var controller = new CreateQuizController(mockRepo.Object, mockGetRepo.Object);

            var categories = new Rest.Api.Models.CategoryModel[1]
            {
                new Rest.Api.Models.CategoryModel
                {
                    Rank = 7
                }
            };

            //act assert
            var statusCode = Assert.IsType<StatusCodeResult>(controller.PutCategoryRanks(categories));
            Assert.Equal(406, statusCode.StatusCode);
        }

        [Fact]
        public void GetReturnsStatusCode101()
        {
            //arrange
            var mockRepo = new Mock<LogLib.Interfaces.ICreateQuizRepository>();
            var mockRepo2 = new Mock<LogLib.Interfaces.IGetDataRepository>();
            var controller = new CreateQuizController(mockRepo.Object, mockRepo2.Object);


            //act



            //assert
            var statusCode = Assert.IsType<StatusCodeResult>(controller.Get());
            Assert.Equal(100, statusCode.StatusCode);
        }
    }
}

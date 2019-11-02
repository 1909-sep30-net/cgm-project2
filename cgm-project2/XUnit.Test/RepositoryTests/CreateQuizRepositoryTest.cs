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
            var category = repo.CreateCategory(categoryId, categoryString, categoryDescription, titleId);

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
            var answer = repo.CreateAnswer(answerId, answerString, weight, categoryId, questionId);

            //assert

            Assert.Equal(expected: answerId + answerString + weight + categoryId + questionId, actual: answer.AnswerId + answer.AnswerString + answer.Weight + answer.CategoryId + answer.QuestionId);
        }

        [Fact]
        public void CreateQuizPushesAllDataToDBCorrectly()
        {
            //arrange

            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("CreateQuizPushesAllDataToDBCorrectly")
                .Options;

            var title = new LogLibMod.Title
            {
                TitleId = 1,
                TitleString = "TitleString",
                CreatorId = 1
            };

            var categories = new List<LogLibMod.Category>
            {
                new LogLibMod.Category
                {
                    CategoryId = 1,
                    CategoryString = "CategoryString1",
                    CategoryDescription = "Desc1",
                    TitleId = title.TitleId
                },
                new LogLibMod.Category
                {
                    CategoryId = 2,
                    CategoryString = "CategoryString2",
                    CategoryDescription = "Desc2",
                    TitleId = title.TitleId
                }
            };

            var questions = new List<LogLibMod.Question>
            {
                new LogLibMod.Question
                {
                    QuestionId = 1,
                    QuestionString = "This is Question?1",
                    TitleId = title.TitleId
                },
                new LogLibMod.Question
                {
                    QuestionId = 2,
                    QuestionString = "This is Question?2",
                    TitleId = title.TitleId
                }
            };

            var answers = new List<LogLibMod.Answer>
            {
                new LogLibMod.Answer
                {
                    AnswerId = 1,
                    AnswerString = "Answer String1",
                    Weight = 1,
                    CategoryId = categories[0].CategoryId,
                    QuestionId = questions[0].QuestionId
                },
                new LogLibMod.Answer
                {
                    AnswerId = 2,
                    AnswerString = "Answer String2",
                    Weight = 1,
                    CategoryId = categories[1].CategoryId,
                    QuestionId = questions[0].QuestionId
                },
                new LogLibMod.Answer
                {
                    AnswerId = 3,
                    AnswerString = "Answer String3",
                    Weight = 1,
                    CategoryId = categories[0].CategoryId,
                    QuestionId = questions[1].QuestionId
                },
                new LogLibMod.Answer
                {
                    AnswerId = 4,
                    AnswerString = "Answer String4",
                    Weight = 1,
                    CategoryId = categories[1].CategoryId,
                    QuestionId = questions[1].QuestionId
                }
            };

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            var repo = new CreateQuizRepository(actContext);

            //act
            repo.CreateQuiz(title, categories, questions, answers);
            repo.Save();

            using var assertContext = new DatLib.Entities.ecgbhozpContext(options);
            var titledb = assertContext.Title.FirstOrDefault();
            var categoriesdb = assertContext.Category.ToList();
            var questionsdb = assertContext.Question.ToList();
            var answersdb = assertContext.Answer.ToList();
            //assert
            Assert.Equal(actual: titledb.TitleString + titledb.CreatorId, expected: title.TitleString + title.CreatorId);
            foreach(var categorydb in categoriesdb)
            {
                for(int i = 0; i < categories.Count(); i++)
                {
                    var category = categories[i];
                    if(categorydb.CategoryString == category.CategoryString)
                    {
                        Assert.Equal(expected: category.CategoryString + category.CategoryDescription, actual:  categorydb.CategoryString + categorydb.CategoryDescription);
                        break;
                    }
                    //if there were no matching categories, fail test.
                    if(i == categories.Count() - 1)
                    {
                        Assert.False(true); //will always fail
                    }
                }
            }
            foreach (var questiondb in questionsdb)
            {
                for (int i = 0; i < questions.Count(); i++)
                {
                    var question = questions[i];
                    if (questiondb.QuestionString == question.QuestionString)
                    {
                        Assert.Equal(expected: question.QuestionString, actual: questiondb.QuestionString);
                        break;
                    }
                    //if there were no matching categories, fail test.
                    if (i == questions.Count() - 1)
                    {
                        Assert.False(true); //will always fail
                    }
                }
            }
            foreach (var answerdb in answersdb)
            {
                for (int i = 0; i < answers.Count(); i++)
                {
                    var answer = answers[i];
                    if (answerdb.AnswerString == answer.AnswerString)
                    {
                        Assert.Equal(expected: answer.AnswerString, actual: answerdb.AnswerString);
                        break;
                    }
                    //if there were no matching categories, fail test.
                    if (i == answers.Count() - 1)
                    {
                        Assert.False(true); //will always fail
                    }
                }
            }
            
        }
    }
}

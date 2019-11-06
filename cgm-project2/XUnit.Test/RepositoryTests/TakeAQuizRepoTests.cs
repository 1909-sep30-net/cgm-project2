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
    public class TakeAQuizRepoTests
    {
        [Fact]
        public void GetQuizByNameOrIdReturnsTitleById()
        {
            //arrange
            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("GetQuizByNameOrIdReturnsTitleById")
                .Options;

            using var arrangeContext = new DatLib.Entities.ecgbhozpContext(options);
            int Id = 102;

            arrangeContext.Title.Add(new DatLib.Entities.Title
            {
                TitleId = 101,
                TitleString = "TestTitle1",
                CreatorId = 51
            });

            arrangeContext.Title.Add(new DatLib.Entities.Title
            {
                TitleId = Id,
                TitleString = "TestTitle2",
                CreatorId = 502
            });

            arrangeContext.Title.Add(new DatLib.Entities.Title
            {
                TitleId = 103,
                TitleString = "TestTitle3",
                CreatorId = 53
            });

            arrangeContext.Title.Add(new DatLib.Entities.Title
            {
                TitleId = 104,
                TitleString = "TestTitle3",
                CreatorId = 54
            });

            arrangeContext.SaveChanges();//save the changes before running the test!
            //act
            using var actContext = new DatLib.Entities.ecgbhozpContext(options);
            var repo = new TakeAQuizRepository(actContext);
            var actual = repo.GetQuizByNameOrId(Id).ToList();
            //assert
            Assert.Equal(expected: Id, actual: actual.Where(t => t.TitleId == Id).FirstOrDefault().TitleId);
        }

        [Fact]
        public void GetQuizByNameOrIdReturnsTitleByTitle()
        {
            //arrange
            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("GetQuizByNameOrIdReturnsTitleByTitle")
                .Options;

            using var arrangeContext = new DatLib.Entities.ecgbhozpContext(options);
            //int Id = 102;
            string testTitle = "TestTitle3";

            arrangeContext.Title.Add(new DatLib.Entities.Title
            {
                TitleId = 101,
                TitleString = "TestTitle1",
                CreatorId = 51
            });

            arrangeContext.Title.Add(new DatLib.Entities.Title
            {
                TitleId = 102,
                TitleString = "testTitle2",
                CreatorId = 502
            });

            arrangeContext.Title.Add(new DatLib.Entities.Title
            {
                TitleId = 103,
                TitleString = testTitle,
                CreatorId = 53
            });

            arrangeContext.Title.Add(new DatLib.Entities.Title
            {
                TitleId = 104,
                TitleString = testTitle,
                CreatorId = 54
            });

            arrangeContext.SaveChanges();//save the changes before running the test!

            //act
            using var actContext = new DatLib.Entities.ecgbhozpContext(options);
            var repo = new TakeAQuizRepository(actContext);
            var actual = repo.GetQuizByNameOrId(title: testTitle).ToList();


            //assert
            Assert.Equal(expected: 2, actual: actual.Count);
        }

        [Fact]
        public void GetQuizReturnsNullWithEmptyString()
        {
            //arrange
            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("GetQuizReturnsNullWithEmptyString")
                .Options;

            using var arrangeContext = new DatLib.Entities.ecgbhozpContext(options);
            using var actContext = new DatLib.Entities.ecgbhozpContext(options);
            var repo = new TakeAQuizRepository(actContext);
            
            //act
            var actual = repo.GetQuiz(title: "");

            //assert
            Assert.Null(actual);
        }

        [Fact]
        public void GetQuizReturnsNullWithNoParams()
        {
            //arrange
            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("GetQuizReturnsNullWithNoParams")
                .Options;

            using var arrangeContext = new DatLib.Entities.ecgbhozpContext(options);
            using var actContext = new DatLib.Entities.ecgbhozpContext(options);
            var repo = new TakeAQuizRepository(actContext);

            //act
            var actual = repo.GetQuiz();

            //assert
            Assert.Null(actual);
        }
    }
}

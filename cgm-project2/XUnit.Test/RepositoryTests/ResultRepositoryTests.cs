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
    public class ResultRepositoryTests
    {
        [Fact]
        public void GetResultsGetsResults()
        {
            //arrange
            //configure the context
            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("GetResultsGetsResults")
                .Options;
            using var arrangeContext = new DatLib.Entities.ecgbhozpContext(options);

            int resultId = 1;
            int score = 5;
            int takerId = 1;
            int titleId = 1;

            var resultEnt = new DatLib.Entities.Result
            {
                ResultId = resultId,
                Score = score,
                TakerId = takerId,
                TitleId = titleId
            };

            arrangeContext.Result.Add(resultEnt);
            arrangeContext.SaveChanges();

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);
            var repo = new ResultRepository(actContext/*, new NullLogger<UserRepository>()*/);

            //act
            List<LogLib.Models.Result> actual = repo.GetResults(resultId).ToList();


            //assert
            Assert.NotEmpty(actual);
        }


    }
}

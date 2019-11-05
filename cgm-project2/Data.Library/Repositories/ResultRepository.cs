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
    public class ResultRepository : IResultRepository
    {
        private readonly Entities.ecgbhozpContext _dbContext;
        public ResultRepository(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public void CalculateDemographics()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogLib.Models.Result> GetResults(int userId = -1)
        {
            if (userId == -1)
                return _dbContext.Result.Select(Mapper.MapResult);
            else
                return _dbContext.Result.Where(r => r.TakerId == userId).Select(Mapper.MapResult);
        }
    }
}

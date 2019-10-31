using System;
using System.Collections.Generic;
using System.Text;
using DatLib = Data.Library;
using LogLib = Logic.Library;

namespace Data.Library.Repositories
{
    public class ResultsRepo
    {
        private readonly Entities.ecgbhozpContext _dbContext;

        public ResultsRepo(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public void AddResultToDb(LogLib.Models.Result result)
        {
            DatLib.Entities.Result newResult = Mapper.MapResult(result);
            _dbContext.Add(newResult);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

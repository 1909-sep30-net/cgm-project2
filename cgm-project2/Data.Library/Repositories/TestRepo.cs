using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogLib = Logic.Library;

namespace Data.Library.Repo
{
    public class TestRepo
    {
        /// <summary>
        /// The Context of the database
        /// </summary>
        private readonly Entities.ecgbhozpContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">The Database Context</param>
        public TestRepo(Entities.ecgbhozpContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// Get items out of the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LogLib.TestClass> GetTest()
        {
            return _dbContext.Testtable.Select(Mapper.MapTest);
        }

    }
}

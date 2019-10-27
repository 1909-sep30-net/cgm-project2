using System;
using System.Collections.Generic;
using System.Text;
using LogLib = Logic.Library;

namespace Data.Library
{
    public static class Mapper
    {
        /// <summary>
        /// Map Db Entities to Logs
        /// </summary>
        /// <param name="testItem"></param>
        /// <returns></returns>
        public static LogLib.TestClass MapTest(Entities.Testtable testItem)
        {
            return new LogLib.TestClass { TestId = testItem.Testid };
        }
    }
}

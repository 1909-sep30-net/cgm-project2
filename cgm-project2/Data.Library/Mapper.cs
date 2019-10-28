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

        //entity to Class
        public static LogLib.Models.User MapUser(Entities.User user)
        {
            return new LogLib.Models.User
            {user.UserId,
             user.FirstName,
             user.LastName,
             user.Street,
             user.City,
             user.State,
             user.Zip
            };
        }

        //class to entity
        public static Entities.User MapUser(LogLib.Models.User user)
        {
            return new Entities.User
            {user.UserId,
             user.FirstName,
             user.LastName,
             user.Street,
             user.City,
             user.State,
             user.Zip
            };
        }




    }
}

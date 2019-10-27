using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using DatLib = Data.Library;
using LogLib = Logic.Library;

namespace TestConsoleApp
{
    /// <summary>
    /// This Project is to be used purely for proto-testing functionality prior to Unit Tests and Runtime tests in Web.App
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Get the dbContext
            var optionsBuilder = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>();
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("db")); //############### The Configuration.GetConnectionString("db") is mocked in the console app by making a class like 'Hidden' called Configuration
            using var dbContext = new DatLib.Entities.ecgbhozpContext(optionsBuilder.Options);

            //Make a Repo
            var testRepo = new DatLib.Repo.TestRepo(dbContext);

            //Use the Repo to get data
            var test = testRepo.GetTest().FirstOrDefault();

            //Write the data to the console
            Console.WriteLine($"The test id is {test.TestId}");
        }
    }
}

using System;
using System.Collections.Generic;
using DatLib = Data.Library;
using Microsoft.EntityFrameworkCore;
using Xunit;
using LogLib = Logic.Library;
using Microsoft.Extensions.Logging.Abstractions;
using Data.Library.Repositories;
using System.Linq;

namespace XUnit.Test
{
    public class UnitTest1
    {
        DatLib.Entities.User userEnt = new DatLib.Entities.User
        {
            UserId = 1,
            FirstName = "Jimmy",
            LastName = "John",
            Street = "2245 Escals Ct.",
            City = "Revat",
            State = "Ur",
            Zip = "e",
            Admin = true
        };

        LogLib.Models.User userLog = new LogLib.Models.User
        {
            UserId = 1,
            FirstName = "Jimmy",
            LastName = "John",
            Street = "2245 Escals Ct.",
            City = "Revat",
            State = "Ur",
            Zip = "e",
            Admin = true
        };

        [Fact]
        public void SearchUsersReturnsAllUsers()
        {
            //arrange
            //configure the context
            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("SearchUsersReturnsAllCustomers")
                .Options;

            //create the context variable and initialize
            using var arrangeContext = new DatLib.Entities.ecgbhozpContext(options);

            //make a test user
            

            arrangeContext.User.Add(userEnt);
            arrangeContext.SaveChanges();

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);
            var repo = new UserRepository(actContext/*, new NullLogger<UserRepository>()*/);

            //act
            List<LogLib.Models.User> actual = repo.SearchUsers().ToList();


            //assert
            Assert.NotNull(actual);
        }
        [Theory]
        [InlineData ("Jimmy","John",true)]
        [InlineData ("Colton","Clary",false)]
        public void SearchUserByNameShouldReturnUser(string firstName, string lastName, bool pass)
        {
            //arrange
            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("SearchUserByNameShouldReturnUser")
                .Options;

            //create the context variable and initialize
            using var arrangeContext = new DatLib.Entities.ecgbhozpContext(options);

            //act
            if(!arrangeContext.User.Contains(userEnt))
            {
                arrangeContext.User.Add(userEnt);
                arrangeContext.SaveChanges();
            }


            using var actContext = new DatLib.Entities.ecgbhozpContext(options);
            var repo = new UserRepository(actContext/*, new NullLogger<UserRepository>()*/);


            List<LogLib.Models.User> actual = repo.SearchUsers(firstName, lastName).ToList();

            //assert
            if (pass)
                Assert.Equal(actual: actual.First().FirstName + actual.First().LastName, expected: userEnt.FirstName + userEnt.LastName);
            else
                Assert.Empty(actual);

        }

        [Fact]

        public void RegisterNewUserMakesNewUser()
        {
            //arrange

            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("RegisterNewUserMakesNewUser")
                .Options;

            //create the context variable and initialize
            using var actContext = new DatLib.Entities.ecgbhozpContext(options);

            //act

            var repo = new UserRepository(actContext);

            repo.RegisterNewUser(userLog);
            repo.Save();

            var actual = actContext.User.FirstOrDefault();

            //assert

            Assert.NotNull(actual);
        }

    }
}

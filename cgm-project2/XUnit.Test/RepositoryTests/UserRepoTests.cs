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
    public class UserRepoTests
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

        [Fact]
        public void DeleteUserDeletesUser()
        {
            //arrange

            var options = new DbContextOptionsBuilder<DatLib.Entities.ecgbhozpContext>()
                .UseInMemoryDatabase("DeleteUserDeletesUser")
                .Options;

            using var arrangeContext = new DatLib.Entities.ecgbhozpContext(options);

            int id = userEnt.UserId;
            arrangeContext.User.Add(userEnt);
            arrangeContext.SaveChanges();

            using var actContext = new DatLib.Entities.ecgbhozpContext(options);
            var repo = new UserRepository(actContext);
            
            //act
            repo.DeleteUser(id);
            repo.Save();
            //assert
            using var assertContext = new DatLib.Entities.ecgbhozpContext(options);

            Assert.Null(assertContext.User.FirstOrDefault(u => u.UserId == id));
        }
    }
}

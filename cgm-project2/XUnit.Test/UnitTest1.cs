using System;
using System.Collections.Generic;
using DLE = Data.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using LLM = Logic.Library.Models;
using Microsoft.Extensions.Logging.Abstractions;
using Data.Library.Repositories;
using System.Linq;

namespace XUnit.Test
{
    public class UnitTest1
    {
        DLE.User user = new DLE.User
        {
            UserId = 1,
            FirstName = "Jimmy",
            LastName = "Crow",
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
            var options = new DbContextOptionsBuilder<DLE.ecgbhozpContext>()
                .UseInMemoryDatabase("SearchUsersReturnsAllCustomers")
                .Options;

            //create the context variable and initialize
            using var arrangeContext = new DLE.ecgbhozpContext(options);

            //make a test user
            

            arrangeContext.User.Add(user);
            arrangeContext.SaveChanges();

            using var actContext = new DLE.ecgbhozpContext(options);
            var repo = new UserRepository(actContext/*, new NullLogger<UserRepository>()*/);

            //act
            List<LLM.User> actual = repo.SearchUsers().ToList();


            //assert
            Assert.NotNull(actual);
        }
        [Fact]

        public void SearchUserByNameShouldReturnUser()
        {
            //arrange
            var options = new DbContextOptionsBuilder<DLE.ecgbhozpContext>()
                .UseInMemoryDatabase("SearchUserByNameShouldReturnUser")
                .Options;

            //create the context variable and initialize
            using var arrangeContext = new DLE.ecgbhozpContext(options);

            //act

            arrangeContext.User.Add(user);
            arrangeContext.SaveChanges();

            using var actContext = new DLE.ecgbhozpContext(options);
            var repo = new UserRepository(actContext/*, new NullLogger<UserRepository>()*/);


            List<LLM.User> actual = repo.SearchUsers("Jimmy", "Crow").ToList();

            //assert

            Assert.Equal(actual: actual.First().FirstName + actual.First().LastName, expected: user.FirstName + user.LastName);
        }

    }
}
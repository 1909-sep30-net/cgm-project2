using System;
using System.Collections.Generic;
using DLE = Data.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using LLM = Logic.Library.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace XUnit.Test
{
    public class UnitTest1
    {

        [Fact]
        public void SearchCustomersReturnsAllCustomers()
        {
            //arrange
            //configure the context
            var options = new DbContextOptionsBuilder<DLE.ecgbhozpContext>()
                .UseInMemoryDatabase("SearchCustomersReturnsAllCustomers")
                .Options;

            //create the context variable and initialize
            using var arrangeContext = new DLE.ecgbhozpContext(options);

            //make a test user
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

            arrangeContext.User.Add(user);
            arrangeContext.SaveChanges();

            using var actContext = new DLE.ecgbhozpContext(options);
            var repo = new UserRepository(actContext, new NullLogger<UserRepository>());

            //act
            List<LLM.User> actual = repo.SearchUsers();


            //assert


        }
    }
}

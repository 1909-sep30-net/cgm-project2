using Microsoft.EntityFrameworkCore;
using Xunit;
using LogLib = Logic.Library;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;
using Moq;
using Data.Library.Repositories;
using LogLibMod = Logic.Library.Models;
using System.Collections;
using System.Collections.Generic;
using Rest.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace XUnit.Test.ControllerTests
{
    public class UserControllerTests
    {
        [Fact]
        public void GetReturnsListOfUsers()
        {
            //arrange

            var mockRepo = new Mock<LogLib.Interfaces.IUserRepository>();
            mockRepo.Setup(r => r.SearchUsers(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<LogLibMod.User> {
                    new LogLibMod.User
                    {
                        UserId = 1,
                        FirstName = "Colton"
                    },
                    new LogLibMod.User
                    {
                        UserId = 2,
                        FirstName = "Greg"
                    }

                });
            var controller = new UserController(mockRepo.Object);


            //act

            var result = controller.Get();

            //assert

            Assert.NotNull(result);
        }

        [Fact]
        public void PostSucceeds()
        {
            //arrange

            var mockRepo = new Mock<LogLib.Interfaces.IUserRepository>();
            mockRepo.Setup(r => r.RegisterNewUser(It.IsAny<LogLibMod.User>()));
            var controller = new UserController(mockRepo.Object);

            //act

            var statusCode = Assert.IsType<StatusCodeResult>(controller.Post(new LogLibMod.User() { }));
            Assert.Equal(202, statusCode.StatusCode);

            //assert

        }
    }
}

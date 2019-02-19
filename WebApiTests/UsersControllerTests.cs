using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using TestowaApkaAndea.Controllers;
using TestowaApkaAndea.Models;
using TestowaApkaAndea.Repository;
using Xunit;

namespace WebApiTests
{
    public class UsersControllerTests
    {
        private UsersController usersController;
        private IRepository repository;

        public UsersControllerTests()
        {
            repository = new MockRepository();
            usersController = new UsersController(repository);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = usersController.Get();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var okResult = usersController.Get().Result as OkObjectResult;
            var items = okResult.Value as IList;
            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var notFoundResult = usersController.Get(10);
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            var id = 1;
            var okResult = usersController.Get(id);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            var id = 1;
            var okResult = usersController.Get(id).Result as OkObjectResult;

            Assert.IsType<User>(okResult.Value);
            Assert.Equal(id, (okResult.Value as User).Id);
        }

        [Fact]
        public void Put_UnkownUserPassed_ReturnsNotFoundResult()
        {
            var userId = 10;
            var testUser = new User()
            {
                Id = userId,
                FirstName = "Imie",
                LastName = "Nazwisko",
                RoleId = 1
            };

            var notFoundResutult = usersController.Put(userId, testUser);
            Assert.IsType<NotFoundResult>(notFoundResutult);
        }

        [Fact]
        public void Put_InvalidRolePassed_ReturnsBadRequestResult()
        {
            var userId = 1;
            var testUser = new User()
            {
                Id = userId,
                RoleId = 10
            };

            var badRequestResult = usersController.Put(userId, testUser);
            Assert.IsType<BadRequestObjectResult>(badRequestResult);
        }

        [Fact]
        public void Put_CorrectDataPassed_ReturnsOKResult()
        {
            var userId = 1;
            var testUser = new User()
            {
                Id = userId,
                RoleId = 2
            };

            var okResult = usersController.Put(userId, testUser);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Put_CorrectDataPassed_UpdatesProperly()
        {
            var userId = 1;
            var testUser = new User()
            {
                Id = userId,
                RoleId = 2
            };

            var OkResult = usersController.Put(userId, testUser);
            Assert.IsType<OkObjectResult>(OkResult);

            var updatedUser = repository.GetUser(userId);
            Assert.Equal(2, updatedUser.RoleId);
        }
    }
}

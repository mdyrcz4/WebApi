using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestowaApkaAndea.Controllers;
using TestowaApkaAndea.Models;
using TestowaApkaAndea.Repository;
using Xunit;

namespace WebApiTests
{
    public class RolesControllerTests
    {
        private RolesController rolesController;
        private IRepository repository;

        public RolesControllerTests()
        {
            repository = new MockRepository();
            rolesController = new RolesController(repository);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = rolesController.Get();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var okResult = rolesController.Get().Result as OkObjectResult;
            var items = okResult.Value as IList;
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var notFoundResult = rolesController.Get(10);
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            var id = 1;
            var okResult = rolesController.Get(id);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            var id = 1;
            var okResult = rolesController.Get(id).Result as OkObjectResult;

            Assert.IsType<Role>(okResult.Value);
            Assert.Equal(id, (okResult.Value as Role).Id);
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TodoMockNet;
using TodoMockNet.Controllers;
using TodoMockNet.Models;
using TodoMockNet.Models.ApiObjects;
using Xunit;
using Assert = Xunit.Assert;

namespace TodoMockNet.Tests.Controllers
{
    [TestClass]
    public class TodoControllerTest
    {
        [TestMethod]
        public void ShouldNot_BeNull()
        {
            // Arrange
            TodoController controller = new TodoController();

            // Act
            IQueryable<Todo> todoes = controller.GetAll();

            // Assert
            Assert.NotNull(todoes);
        }

        [TestMethod]
        public async Task Should_ValidateCreationAsync()
        {
            // Arrange
            TodoController controller = new TodoController();

            // Act
            IQueryable<Todo> prevTodoes = controller.GetAll();
            AddTodoObject addTodoObject = new AddTodoObject("Testing");
            Task<IHttpActionResult> result = (Task<IHttpActionResult>)await controller.Create(addTodoObject);
            List<Todo> newTodoes = result.Result as List<Todo>;
            // Assert

            Assert.NotNull(prevTodoes);
            Assert.NotNull(newTodoes);
            Assert.True(newTodoes.Count > prevTodoes.Count());
        }

        //[Fact]
        //public void Should_Validate()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Post("value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Put()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Put(5, "value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Delete()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Delete(5);

        //    // Assert
        //}
    }
}

using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TodoMockNet.Models.ApiObjects;
using TodoMockNet.Services;
using TodoMockNet.Services.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace TodoMockNet.XUnit.Controllers
{
    public class TodoTest
    {
        [Fact]
        public async Task Should_ValidateGetAllAsync()
        {
            // Arrange
            ITodoManager todoManager = new TodoManager();

            // Act
            TodoResultObject result = await todoManager.GetAll();

            // Assert
            Assert.NotNull(result.Todoes);
        }

        [Fact]
        public async Task Should_ValidateCreationAsync()
        {
            // Arrange
            ITodoManager todoManager = new TodoManager();
            AddTodoObject addTodoObject = new AddTodoObject("Testing.XUNIT");


            // Act
            TodoResultObject newResult = await todoManager.Create(addTodoObject);

            // Assert
            Assert.NotNull(newResult);
            Assert.Equal(HttpStatusCode.OK, newResult.StatusCode);
            Assert.True(newResult.Todoes.Count > 0);
        }

        [Fact]
        public async Task Should_ValidateCreation_Then_DeletionAsync()
        {
            // Arrange
            ITodoManager todoManager = new TodoManager();
            AddTodoObject addTodoObject = new AddTodoObject("Testing.XUNIT");

            // Act
            TodoResultObject newResult = await todoManager.Create(addTodoObject);
            TodoResultObject deleteResult = await todoManager.Delete(newResult.Todoes.First());

            // Assert
            Assert.NotNull(deleteResult);
            Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);
        }
    }
}

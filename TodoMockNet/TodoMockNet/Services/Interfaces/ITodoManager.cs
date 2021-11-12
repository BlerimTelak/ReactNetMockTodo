using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TodoMockNet.Models;
using TodoMockNet.Models.ApiObjects;

namespace TodoMockNet.Services.Interfaces
{
    public interface ITodoManager
    {
        Task<TodoResultObject> GetAll();
        Task<TodoResultObject> Get(int id);
        Task<TodoResultObject> Create(AddTodoObject input);
        Task<TodoResultObject> Delete(Todo todo);
        Task<TodoResultObject> Toggle(Todo todo);

    }
}
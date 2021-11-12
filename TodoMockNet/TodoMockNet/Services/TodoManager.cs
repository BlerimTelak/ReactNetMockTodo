using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TodoMockNet.Data;
using TodoMockNet.Models;
using TodoMockNet.Models.ApiObjects;
using TodoMockNet.Services.Interfaces;

namespace TodoMockNet.Services
{
    public class TodoManager : ITodoManager
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task<TodoResultObject> GetAll()
        {
            TodoResultObject result = new TodoResultObject();
            List<Todo> todoes = await db.Todoes.Where(t => t.isDeleted == false).OrderBy(t => t.createdAt).ToListAsync();
            result.Todoes = todoes;
            return result;
        }

        public async Task<TodoResultObject> Get(int id)
        {
            TodoResultObject result = new TodoResultObject();
            Todo todo = await db.Todoes.Where(t => !t.isDeleted && t.id == id).FirstOrDefaultAsync();
            if (todo == null)
            {
                result.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                result.Todoes.Add(todo);
            }
            return result;
        }

        public async Task<TodoResultObject> Toggle(Todo todo)
        {
            TodoResultObject result = new TodoResultObject();
            if (todo == null)
            {
                result.StatusCode = HttpStatusCode.NotFound;
                return result;
            }
            todo.isFinished = !todo.isFinished;
            todo.modifiedAt = DateTime.UtcNow;
            await db.SaveChangesAsync();
            result.Todoes.Add(todo);

            return result;
        }

        public async Task<TodoResultObject> Create(AddTodoObject input)
        {
            TodoResultObject result = new TodoResultObject();
            if (input.text.Length < 1)
            {
                result.StatusCode = HttpStatusCode.BadRequest;
                return result;
            }
            Todo todo = new Todo(input.text);
            db.Todoes.Add(todo);
            await db.SaveChangesAsync();
            result.Todoes = await db.Todoes.Where(t => !t.isDeleted).ToListAsync();

            return result;
        }

        public async Task<TodoResultObject> Delete(Todo todo)
        {
            TodoResultObject result = new TodoResultObject();
            if (todo == null)
            {
                result.StatusCode = HttpStatusCode.NotFound;
                return result;
            }
            todo.isDeleted = true;
            todo.modifiedAt = DateTime.UtcNow;
            await db.SaveChangesAsync();
            result.Todoes.Add(todo);

            return result;
        }
    }
}
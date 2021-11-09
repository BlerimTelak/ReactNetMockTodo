using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TodoMockNet.Data;
using TodoMockNet.Models;
using TodoMockNet.Models.ApiObjects;

namespace TodoMockNet.Controllers
{
    public class TodoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Todo/GetAll
        [HttpGet]
        public IQueryable<Todo> GetAll()
        {
            return db.Todoes.Where(t => !t.isDeleted);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Toggle(int id)
        {
            List<Todo> todoes = await db.Todoes.Where(t => !t.isDeleted).ToListAsync();
            Todo todo = todoes.Find(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.isFinished = !todo.isFinished;
            todo.modifiedAt = DateTime.UtcNow;
            await db.SaveChangesAsync();

            return Ok(todoes);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(AddTodoObject input)
        {
            if(input.text.Length < 2)
            {
                return BadRequest();
            }
            Todo todo = new Todo(input.text);
            db.Todoes.Add(todo);
            await db.SaveChangesAsync();

            return Ok(await db.Todoes.Where(t => !t.isDeleted).ToListAsync());
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(int id)
        {
            List<Todo> todoes = await db.Todoes.Where(t => t.isDeleted == false).ToListAsync();
            Todo todo = todoes.Find(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.isDeleted = true;
            todo.modifiedAt = DateTime.UtcNow;
            await db.SaveChangesAsync();
            todoes.Remove(todo);

            return Ok(todoes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoExists(int id)
        {
            return db.Todoes.Count(e => e.id == id) > 0;
        }
    }
}
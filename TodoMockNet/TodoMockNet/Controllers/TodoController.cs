using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TodoMockNet.Data;
using TodoMockNet.Models.ApiObjects;
using TodoMockNet.Services.Interfaces;

namespace TodoMockNet.Controllers
{
    public class TodoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ITodoManager todoManager;
        public TodoController()
        {

        }
        public TodoController(ITodoManager todoManager)
        {
            this.todoManager = todoManager ?? throw new ArgumentNullException(nameof(todoManager));
        }

        // GET: api/Todo/GetAll
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                TodoResultObject result = await todoManager.GetAll();
                return ResponseMessage(Request.CreateResponse(result.StatusCode, result.Todoes));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Toggle(int id)
        {
            try
            {
                TodoResultObject getTodo = await todoManager.Get(id);
                if(getTodo.StatusCode != HttpStatusCode.OK)
                    return ResponseMessage(Request.CreateResponse(getTodo.StatusCode, getTodo.Todoes));

                TodoResultObject toggleResult = await todoManager.Toggle(getTodo.Todoes.First());
                TodoResultObject allTodoes = await todoManager.GetAll();
                return ResponseMessage(Request.CreateResponse(toggleResult.StatusCode, allTodoes.Todoes));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(AddTodoObject input)
        {
            try
            {
                TodoResultObject toggleResult = await todoManager.Create(input);
                TodoResultObject allTodoes = await todoManager.GetAll();
                return ResponseMessage(Request.CreateResponse(toggleResult.StatusCode, allTodoes.Todoes));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                TodoResultObject getTodo = await todoManager.Get(id);
                if (getTodo.StatusCode != HttpStatusCode.OK)
                    return ResponseMessage(Request.CreateResponse(getTodo.StatusCode, getTodo.Todoes));

                TodoResultObject deleteResult = await todoManager.Delete(getTodo.Todoes.First());
                TodoResultObject allTodoes = await todoManager.GetAll();
                return ResponseMessage(Request.CreateResponse(deleteResult.StatusCode, allTodoes.Todoes));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
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
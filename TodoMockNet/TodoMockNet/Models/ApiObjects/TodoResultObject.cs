using System.Collections.Generic;
using System.Net;

namespace TodoMockNet.Models.ApiObjects
{
    public class TodoResultObject
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<Todo> Todoes { get; set; }
        public TodoResultObject()
        {
            StatusCode = HttpStatusCode.OK;
            Todoes = new List<Todo>();
        }
        public TodoResultObject(HttpStatusCode httpStatus, List<Todo> todoes)
        {
            StatusCode = httpStatus;
            Todoes = todoes;
        }
    }


}
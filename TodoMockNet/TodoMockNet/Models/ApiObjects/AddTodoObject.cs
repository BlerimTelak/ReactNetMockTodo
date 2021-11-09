using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoMockNet.Models.ApiObjects
{
    public class AddTodoObject
    {
        public string text { get; set; }
        public AddTodoObject()
        {

        }

        public AddTodoObject(string text)
        {
            this.text = text;
        }
    }
}
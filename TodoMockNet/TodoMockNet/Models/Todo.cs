using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoMockNet.Models
{
    public class Todo
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool isFinished { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime modifiedAt { get; set; }
        public bool isDeleted { get; set; }

        public Todo()
        {

        }
        public Todo(string input)
        {
            text = input;
            createdAt = DateTime.UtcNow;
            modifiedAt = DateTime.UtcNow;
            isFinished = false;
            isDeleted = false;
        }
    }
}
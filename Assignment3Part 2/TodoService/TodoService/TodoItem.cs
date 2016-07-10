using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoService
{
    public class TodoItem
    {
        public string Title = String.Empty;
        public bool Complete = false;
        public Guid ItemId = Guid.NewGuid();
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TodoService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TodoService : ITodoService
    {
        private TodoItems items = new TodoItems();

        public void AddTodoItem(string title)
        {
            TodoItem item = new TodoItem();
            item.Title = title;
            items.todoList.Add(item);
        }

        // Marks the specified item as complete
        public void ModifyToDoItem(Guid id, string operation)
        {
            var count = 0;

            foreach (var item in items.todoList)
            {
                if (item.ItemId == id && operation == "complete")
                {
                    item.Complete = true;
                }
                else if (item.ItemId == id && operation == "delete")
                {
                    items.todoList.RemoveAt(count);
                    break;
                }
                else
                {
                    count++;
                }
            }
        }

        // Returns the contents of the to do list
        public TodoItems GetToDoList()
        {
            return items;
        }
    }
}

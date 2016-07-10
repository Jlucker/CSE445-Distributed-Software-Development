using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace TodolistService
{
    public class TodolistService : ITodolistService
    {
        /// <summary>
        /// Gets the Todolist data for all users
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns all Todolist items</returns>
        public TodoList GetTodoList()
        {

            return DeserializeTodoData();

        }

        /// <summary>
        /// Gets the Todolist data for the specified user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the Todolist items for the specified user</returns>
        public TodoList GetUsersTodoList(string user)
        {

            return DeserializeTodoData();

        }

        /// <summary>
        /// Adds a TodoItem to the user's TodoList
        /// </summary>
        /// <param name="item"></param>
        public void AddTodoItem(TodoItem item)
        {
            var list = DeserializeTodoData();
            list.TodoItem.Add(item);
            SerializeTodoData(list);
        }

        /// <summary>
        /// Deletes a TodoItem from the user's TodoList
        /// </summary>
        /// <param name="item"></param>
        public void DeleteTodoItem(TodoItem item)
        {
            var list = DeserializeTodoData();

            var index = 0;
            foreach (var todo in list.TodoItem)
            {
                if (todo.GlobalID.Equals(item.GlobalID) && todo.ListID.Equals(item.ListID) &&
                    todo.ItemID.Equals(item.ItemID))
                {
                    list.TodoItem.RemoveAt(index);
                    break;
                }
                index++;
            }
            SerializeTodoData(list);
        }

        /// <summary>
        /// Edits an item in the TodoList
        /// </summary>
        /// <param name="item"></param>
        public void EditTodoItem(TodoItem item)
        {
            var list = DeserializeTodoData();
            TodoList newList = new TodoList();

            var index = 0;
            foreach (var todo in list.TodoItem)
            {
                if (todo.GlobalID.Equals(item.GlobalID) && todo.ListID.Equals(item.ListID) &&
                    todo.ItemID.Equals(item.ItemID))
                {
                    newList = UpdateItem(list, index, item);
                    break;
                }
                index++;
            }
            SerializeTodoData(newList);
        }

        /// <summary>
        /// Completes the specified item in the user's TodoList
        /// </summary>
        /// <param name="item"></param>
        public void CompleteTodoItem(TodoItem item)
        {
            var list = DeserializeTodoData();

            var index = 0;
            foreach (var todo in list.TodoItem)
            {
                if (todo.GlobalID.Equals(item.GlobalID) && todo.ListID.Equals(item.ListID) &&
                    todo.ItemID.Equals(item.ItemID))
                {
                    list.TodoItem.ElementAt(index).ItemComplete = "true";
                    break;
                }
                index++;
            }
            SerializeTodoData(list);
        }

        /// <summary>
        /// Serialized the TodoList data and rewrites the TodoData XML file
        /// </summary>
        /// <param name="todoList"></param>
        private void SerializeTodoData(TodoList todoList)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Data/TodoData.xml");
            XmlSerializer serializer = new XmlSerializer(todoList.TodoItem.GetType(), new XmlRootAttribute("TodoList"));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer.BaseStream, todoList.TodoItem);
            }
        }

        /// <summary>
        /// Deserializes the Todolist XML data
        /// </summary>
        /// <returns>Returns the deserialized Todolist data</returns>
        private TodoList DeserializeTodoData()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Data/TodoData.xml");
            XmlSerializer deserializer = new XmlSerializer(typeof(TodoList));
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                return (TodoList)deserializer.Deserialize(fileStream);
            }
        }

        /// <summary>
        /// Updates the specified item in the TodoList
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <returns>Returns the updated TodoList</returns>
        private TodoList UpdateItem(TodoList list, int index, TodoItem item)
        {
            list.TodoItem.ElementAt(index).ItemComplete = item.ItemComplete;
            list.TodoItem.ElementAt(index).ItemDateCreated = item.ItemDateCreated;
            list.TodoItem.ElementAt(index).ItemDueDate = item.ItemDueDate;
            list.TodoItem.ElementAt(index).ItemLabel = item.ItemLabel;
            list.TodoItem.ElementAt(index).ItemNotes = item.ItemNotes;
            list.TodoItem.ElementAt(index).ListLabel = item.ListLabel;

            return list;
        }
    }
}

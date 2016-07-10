using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TodolistService
{
    [ServiceContract]
    public interface ITodolistService
    {

        [OperationContract]
        TodoList GetTodoList();

        [OperationContract]
        TodoList GetUsersTodoList(string userId);

        [OperationContract]
        void AddTodoItem(TodoItem item);

        [OperationContract]
        void DeleteTodoItem(TodoItem item);

        [OperationContract]
        void CompleteTodoItem(TodoItem item);

        [OperationContract]
        void EditTodoItem(TodoItem item);

    }
}

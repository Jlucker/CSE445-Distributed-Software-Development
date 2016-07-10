using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TodoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITodoService
    {

        [OperationContract]
        void AddTodoItem(string title);

        [OperationContract]
        void ModifyToDoItem(Guid id, string operation);

        [OperationContract]
        TodoItems GetToDoList();
    }
}

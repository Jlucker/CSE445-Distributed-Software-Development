using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AuthService
{
    [ServiceContract]
    public interface IAuthService
    {

        [OperationContract]
        string Authenticate(string authUserId, string type);

        [OperationContract]
        string AuthenticateUsername(string username, string password, string type);

        [OperationContract]
        bool CreateUser(Auth auth);

        [OperationContract]
        void DeleteUser(Auth auth);

        [OperationContract]
        Auths GetAuths();

        [OperationContract]
        void AddRoles(Auth auth, string type);

    }
}

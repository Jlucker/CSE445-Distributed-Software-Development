using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace AuthService
{
    public class AuthService : IAuthService
    {
        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="auth"></param>
        /// <returns>Returns a confirmation string</returns>
        public string Authenticate(string authUserId, string type)
        {
            var auths = DeserializeAuthData();
            foreach (var auth in auths.Auth)
            {
                if (auth.Uid.Equals(authUserId))
                {
                    if (auth.UserType.Contains(type))
                    {
                        return "Authenticated";
                    }
                    else
                    {
                        return "Current User Roles:" + auth.UserType;
                    }
                }
            }
            return "User Does Not Exist";
        }


        /// <summary>
        /// Authenticates a user using their username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="type"></param>
        /// <returns>Returns a confirmation string</returns>
        public string AuthenticateUsername(string username, string password, string type)
        {
            var auths = DeserializeAuthData();
            foreach (var auth in auths.Auth)
            {
                if (auth.Username.Equals(username) && auth.Password.Equals(password))
                {
                    if (auth.UserType.Contains(type))
                    {
                        return "Authenticated";
                    }
                    else
                    {
                        return "Current User Roles:" + auth.UserType;
                    }
                }
            }
            return "User Does Not Exist";
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="auth"></param>
        /// <returns>Returns a true if the user already exists and false otherwise</returns>
        public bool CreateUser(Auth auth)
        {
            var auths = DeserializeAuthData();

            if (CheckUsername(auths, auth))
            {
                return true;
            }
            else
            {
                auths.Auth.Add(auth);
                SerializeAuthData(auths);
                return false;
            }
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="auth"></param>
        /// <returns>Returns a confirmation string</returns>
        public void DeleteUser(Auth auth)
        {
            var auths = DeserializeAuthData();
            auths = CheckAuths(auths, auth);
            SerializeAuthData(auths);
        }

        /// <summary>
        /// Gets the auth data
        /// </summary>
        /// <returns>Returns an object of type Auth</returns>
        public Auths GetAuths()
        {
            return DeserializeAuthData();
        }

        /// <summary>
        /// Adds a role to the specified user
        /// </summary>
        /// <param name="authQuery"></param>
        /// <param name="type"></param>
        public void AddRoles(Auth authQuery, string type)
        {
            var auths = DeserializeAuthData();
            foreach (var auth in auths.Auth)
            {
                // If the user id matches and does not already contain the type
                if (auth.Uid.Equals(authQuery.Uid) && !auth.UserType.Contains(type))
                {
                    auth.UserType += type;
                }
            }
            SerializeAuthData(auths);
        }

        /// <summary>
        /// Serializes the Auths object and rewrites the AuthData file
        /// </summary>
        /// <param name="auths"></param>
        private void SerializeAuthData(Auths auths)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Data/AuthData.xml");
            XmlSerializer serializer = new XmlSerializer(auths.Auth.GetType(), new XmlRootAttribute("Auths"));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer.BaseStream, auths.Auth);
            }
        }

        /// <summary>
        /// Deserializes the AuthData.xml file and returns a Auths object
        /// </summary>
        /// <returns>Returns an Auths object populated with data</returns>
        private Auths DeserializeAuthData()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Data/AuthData.xml");
            XmlSerializer deserializer = new XmlSerializer(typeof(Auths));
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                return (Auths)deserializer.Deserialize(fileStream);
            }
        }

        /// <summary>
        /// Checks if a user exists and removes them if they do
        /// </summary>
        /// <param name="auths"></param>
        /// <param name="authDelete"></param>
        /// <returns>Returns the updated Auth List</returns>
        private Auths CheckAuths(Auths auths, Auth authDelete)
        {
            var index = 0;

            foreach (var auth in auths.Auth)
            {
                if (auth.Uid == authDelete.Uid)
                {
                    auths.Auth.RemoveAt(index);
                    break;
                }
                index++;
            }
            return auths;
        }

        /// <summary>
        /// Checks if a username already exists
        /// </summary>
        /// <param name="auths"></param>
        /// <param name="authCheck"></param>
        /// <returns>Returns true if username exists and false otherwise</returns>
        private bool CheckUsername(Auths auths, Auth authCheck)
        {
            foreach (var auth in auths.Auth)
            {
                if (auth.Username.Equals(authCheck.Username))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

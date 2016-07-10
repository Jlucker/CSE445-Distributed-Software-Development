using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment5WebApp.AuthServiceReference;
using EncryptionService;

namespace Assignment5WebApp
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Calls LoginExistingUser when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ExistingUserButton_OnClick(object sender, EventArgs e)
        {
           LoginExistingUser();
        }

        /// <summary>
        /// Authenticates the specified user
        /// </summary>
        private void LoginExistingUser()
        {
            var username = ExistingUserNameTextBox.Text;
            var password = ExistingPasswordTextBox.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                EncryptionService.EncryptionService es = new EncryptionService.EncryptionService();
                AuthServiceClient client = new AuthServiceClient();

                password = es.Encrypt(password);
                var response = client.AuthenticateUsername(username, password, "1");

                if (response.Equals("Authenticated"))
                {
                    Session["Staff1Auth"] = null;
                    Session["Staff2Auth"] = null;
                    Session["MemberAuth"] = username;
                    Session.Timeout = 15;
                    Response.Redirect("~/MemberHome.aspx");
                }
                else
                {
                    ExisingMemberLabel.Text = response;
                }
            }
        }

        /// <summary>
        /// Creates a new user when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NewUserButton_OnClick(object sender, EventArgs e)
        {
            var username = NewUserTextBox.Text;
            var password = NewUserPasswordTextBox.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                EncryptionService.EncryptionService es = new EncryptionService.EncryptionService();
                AuthServiceClient client = new AuthServiceClient();
           
                password = es.Encrypt(password);
                Auth auth = new Auth();
                auth.Uid = Guid.NewGuid().ToString().ToUpper();
                auth.UserType = "1";
                auth.Password = password;
                auth.Username = username;

                var response = client.CreateUser(auth);

                if (!response)
                {
                    Session["MemberAuth"] = username;
                    Session.Timeout = 5;
                    Response.Redirect("~/MemberHome.aspx");
                }
                else
                {
                    NewMemberLabel.Text = "Username already exists!";
                }
            }
        }

        /// <summary>
        /// Loads preset username and password into the fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoadTestInfoButton_OnClick(object sender, EventArgs e)
        {
            ExistingUserNameTextBox.Text = "TestUser1";
            ExistingPasswordTextBox.Text = "test";
        }
    }
}
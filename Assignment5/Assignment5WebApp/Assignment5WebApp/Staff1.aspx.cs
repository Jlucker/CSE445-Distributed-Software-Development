using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment5WebApp.AuthServiceReference;

namespace Assignment5WebApp
{
    public partial class Staff1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Calls the LoginExistingUser method when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ExistingUserButton_OnClick(object sender, EventArgs e)
        {
            LoginExistingUser();
        }

        /// <summary>
        /// Authenticates the user based on the provided credentials
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
                var response = client.AuthenticateUsername(username, password, "2");

                if (response.Equals("Authenticated"))
                {
                    Session["Staff2Auth"] = null;
                    Session["MemberAuth"] = null;
                    Session["Staff1Auth"] = username;
                    Session.Timeout = 15;
                    Response.Redirect("~/Staff1Home.aspx");
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
                auth.UserType = "2";
                auth.Password = password;
                auth.Username = username;

                var response = client.CreateUser(auth);

                if (!response)
                {
                    Session["MemberAuth"] = null;
                    Session["Staff2Auth"] = null;
                    Session["Staff1Auth"] = username;
                    Session.Timeout = 5;
                    Response.Redirect("~/Staff1Home.aspx");
                }
                else
                {
                    NewUserLabel.Text = "Username already exists!";
                }
            }
        }
        /// <summary>
        /// Loads the test account into the textboxes for easy testing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoadTestInfoButton_OnClick(object sender, EventArgs e)
        {
            ExistingUserNameTextBox.Text = "Staff1TestUser";
            ExistingPasswordTextBox.Text = "test";
        }
    }
}
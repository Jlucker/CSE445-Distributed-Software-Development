using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment5WebApp.AuthServiceReference;
using EncryptionService;

namespace Assignment5WebApp
{
    public partial class AuthService_TryIt : System.Web.UI.Page
    {
        Random random = new Random();

        /// <summary>
        /// Refreshes all of the dropdown menus and populates the user table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthUserDropDown.Items.Clear();
            DeleteUserDropDown.Items.Clear();
            AuthServiceClient client = new AuthServiceClient();
            var auths = client.GetAuths();
            foreach (var auth in auths.Auth)
            {
                AuthUserDropDown.Items.Add(new ListItem(auth.Username, auth.Uid));
                DeleteUserDropDown.Items.Add(new ListItem(auth.Username, auth.Uid));
                AddRolesDropDownList.Items.Add(new ListItem(auth.Username, auth.Uid));
            }
            PopulateUserTable();
        }

        /// <summary>
        /// Adds a user when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AuthUserButton_OnClick(object sender, EventArgs e)
        {
            AuthUser();

        }

        /// <summary>
        /// Authenticates user and sets the label to the response value
        /// </summary>
        private void AuthUser()
        {
            AuthServiceClient client = new AuthServiceClient();
            var response = client.Authenticate(AuthUserDropDown.SelectedValue, UserRoleDropDown.SelectedValue);
            AuthUSerLabel.Text = response;
        }

        /// <summary>
        /// Creates a new user when the button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateUserButton_OnClick(object sender, EventArgs e)
        {
            CreateUser();
        }

        /// <summary>
        /// Creates a new user using the data provided in the text fields
        /// </summary>
        private void CreateUser()
        {
            AuthServiceClient authClient = new AuthServiceClient();
            EncryptionService.EncryptionService encClient = new EncryptionService.EncryptionService();
            Auth auth = new Auth();
            Guid uid = Guid.NewGuid();

            auth.Username = CreateUserTextBox.Text;
            auth.Password = encClient.Encrypt(CreateUserPasswordTextBox.Text);
            auth.Uid = uid.ToString().ToUpper();

            StringBuilder builder = new StringBuilder();

            foreach (ListItem item in CreateUserRoleCheckBox.Items)
            {
                if (item.Selected)
                {
                    builder.Append(item.Value);
                }
            }
            auth.UserType = builder.ToString();
            var response = authClient.CreateUser(auth);

            if (response)
            {
                CreateUserLabel.Text = "Username Already Exists";
            }
            else
            {
                CreateUserLabel.Text = "User Created";
            }
            
            RefreshFields();
        }

        /// <summary>
        /// Deletes the specified user when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteUserButton_OnClick(object sender, EventArgs e)
        {
            DeleteUser();
        }

        /// <summary>
        /// Deletes the specified user from the AuthData.xml doc
        /// </summary>
        private void DeleteUser()
        {
            AuthServiceClient client = new AuthServiceClient();
            Auth auth = new Auth();
            auth.Uid = DeleteUserDropDown.SelectedValue;
            client.DeleteUser(auth);
            DeleteUserLabel.Text = "User Deleted";
            RefreshFields();
        }

        /// <summary>
        /// Adds roles to the specified user when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddRolesButton_OnClick(object sender, EventArgs e)
        {
           AddRoles();
        }

        /// <summary>
        /// Adds the specified roles to the specified user
        /// </summary>
        private void AddRoles()
        {
            AuthServiceClient client = new AuthServiceClient();
            Auth auth = new Auth();
            auth.Uid = AddRolesDropDownList.SelectedValue;
            StringBuilder builder = new StringBuilder();

            foreach (ListItem item in AddRolesCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    builder.Append(item.Value);
                }
            }
            var userType = builder.ToString();

            client.AddRoles(auth, userType);
            AddRolesLabel.Text = "User Roles Updated!";
            RefreshFields();
        }

        /// <summary>
        /// Popualtes the user table with data from the AuthData.xml file
        /// </summary>
        private void PopulateUserTable()
        {
            UserTable.Rows.Clear();

            AuthServiceClient client = new AuthServiceClient();

            var users = client.GetAuths();

            users.Auth = users.Auth.OrderBy(u => u.Username).ToArray();

            var shading = 0;
            foreach (var user in users.Auth)
            {
                TableRow row1 = new TableRow();
                row1.BackColor = CheckColor(shading);
                row1.ForeColor = CheckFontColor(shading);

                TableCell usernameCell = new TableCell();
                usernameCell.Text = user.Username;
                usernameCell.Font.Size = 16;
                usernameCell.ColumnSpan = 2;
                row1.Cells.Add(usernameCell);



                TableRow row2 = new TableRow();
                row2.BackColor = CheckColor(shading);
                row2.ForeColor = CheckFontColor(shading);

                TableCell passwordCell = new TableCell();
                passwordCell.Text = "Password (Encrypted):";
                //passwordCell.Width = 50;
                passwordCell.Font.Bold = true;
                row2.Cells.Add(passwordCell);

                TableCell pwCell = new TableCell();
                pwCell.Text = user.Password;
                row2.Cells.Add(pwCell);



                TableRow row3 = new TableRow();
                row3.BackColor = CheckColor(shading);
                row3.ForeColor = CheckFontColor(shading);

                TableCell uidCell = new TableCell();
                uidCell.Text = "Universal ID:";
                //uidCell.Width = 50;
                uidCell.Font.Bold = true;
                row3.Cells.Add(uidCell);

                TableCell uCell = new TableCell();
                uCell.Text = user.Uid;
                row3.Cells.Add(uCell);



                TableRow row4 = new TableRow();
                row4.BackColor = CheckColor(shading);
                row4.ForeColor = CheckFontColor(shading);

                TableCell roleCell = new TableCell();
                roleCell.Text = "User Roles:";
                //roleCell.Width = 50;
                roleCell.Font.Bold = true;
                row4.Cells.Add(roleCell);

                TableCell rCell = new TableCell();
                rCell.Text = user.UserType;
                row4.Cells.Add(rCell);

                UserTable.Rows.Add(row1);
                UserTable.Rows.Add(row2);
                UserTable.Rows.Add(row3);
                UserTable.Rows.Add(row4);

                if (shading == 0)
                {
                    shading = 1;
                }
                else
                {
                    shading = 0;
                }
            }
        }

        /// <summary>
        /// Checks the color
        /// </summary>
        /// <param name="shading"></param>
        /// <returns>Returns the corresponding color</returns>
        private Color CheckColor(int shading)
        {
            if (shading == 0)
            {
                return Color.FromArgb(66, 139, 202);
            }
            else
            {
                return Color.Empty;
            }
        }

        /// <summary>
        /// Checks the font color
        /// </summary>
        /// <param name="shading"></param>
        /// <returns>Returns the corresponding font color</returns>
        private Color CheckFontColor(int shading)
        {
            if (shading == 0)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }

        /// <summary>
        /// Calls load data when the button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoadDataButton_OnClick(object sender, EventArgs e)
        {
            for (var i = 0; i < 11; i++)
            {
                LoadData();
            }
            RefreshFields();
        }

        /// <summary>
        /// Refreshes the fields in the control panel
        /// </summary>
        private void RefreshFields()
        {
            AuthUserDropDown.Items.Clear();
            DeleteUserDropDown.Items.Clear();
            AuthServiceClient client = new AuthServiceClient();
            var auths = client.GetAuths();
            foreach (var auth in auths.Auth)
            {
                AuthUserDropDown.Items.Add(new ListItem(auth.Username, auth.Uid));
                DeleteUserDropDown.Items.Add(new ListItem(auth.Username, auth.Uid));
                AddRolesDropDownList.Items.Add(new ListItem(auth.Username, auth.Uid));
            }
            PopulateUserTable();
            CreateUserTextBox.Text = string.Empty;
            CreateUserPasswordTextBox.Text = string.Empty;
        }
        /// <summary>
        /// Loads randomly generated data into the AuthData.xml doc
        /// </summary>
        private void LoadData()
        {
            List<string> firstNames = new List<string>() {"Noah", "Emma", "Liam", "Olivia", "Mason", "Sophia",
                                                      "Jacob", "Ava", "William", "Isabella", "Ethan","Mia",
                                                      "James", "Abigail", "Alexander", "Emily", "Michael",
                                                      "Charlotte", "Benjamin", "Harper"};
            List<string> lastNames = new List<string>() {"Archer", "Ingram", "Figueroa", "Newman", "Wilkerson",
                                                     "Washington", "Bowen", "Graham", "Moss", "Franklin",
                                                     "Beck", "Payne", "Hopkins", "Drake","Mason", "Wagner",
                                                     "Flores", "Riley", "Kopp", "Ochoa", "Pak"};

            List<string> passwordElements = new List<string>()
            {
                "Melee",
                "Tourer",
                "Derry",
                "Invade",
                "Vacuity",
                "Amputate",
                "jukebox",
                "dainty",
                "bell",
                "stewed",
                "flipper",
                "buyer",
                "boring",
                "asquint",
                "signory",
                "polygon",
                "glasses",
                "dulse",
                "noddle",
                "dropsy",
                "tadpole",
                "twine",
                "moonshot",
                "alderman"
            };

            var randomFirst = random.Next(0, firstNames.Count);
            var firstName = firstNames.ElementAt(randomFirst);

            var randomLast = random.Next(0, firstNames.Count);
            var lastName = lastNames.ElementAt(randomLast);

            var usernameNumber = random.Next(1, 100);
            var usernameFirst = firstName.Substring(0, 1);
            var usernameLast = lastName;
            var username = usernameFirst.ToLower() + usernameLast.ToLower() + usernameNumber;

            var pwFirst = passwordElements.ElementAt(random.Next(0, passwordElements.Count));
            var pwLast = passwordElements.ElementAt(random.Next(0, passwordElements.Count));
            var pwNum = random.Next(0, 999);
            var password = pwFirst + pwLast + pwNum;

            Guid uid = Guid.NewGuid();

            Auth auth = new Auth();
            AuthServiceClient authClient = new AuthServiceClient();
            EncryptionService.EncryptionService encClient = new EncryptionService.EncryptionService();

            auth.Username = username;
            auth.Password = encClient.Encrypt(password);
            auth.Uid = uid.ToString().ToUpper();
            auth.UserType = "1";

            authClient.CreateUser(auth);
        }
    }
}
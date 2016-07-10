using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment5WebApp.AuthServiceReference;
using Assignment5WebApp.TodoListServiceReference;
using Assignment5WebApp.WeatherServiceReference;

namespace Assignment5WebApp
{
    public partial class MemberHome : System.Web.UI.Page
    {
        private string user = "";
        
        /// <summary>
        /// Ensures that the user is authorized to access the page and refreshes data on the page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberAuth"] != null)
            {
                user = (string) Session["MemberAuth"];
                MemberHomeLabel.Text = "Welcome " + user;
            }
            else
            {
                Response.Redirect("Member.aspx");
            }

            if (!IsPostBack)
            {
                // Populate weather for the default location
                WeatherTextBox.Text = "85281";
                PopulateWeather("85281");
                
            }
            if (Session["WeatherLocation"] != null)
            {
                var location = (string) Session["WeatherLocation"];
                PopulateWeather(location);
            }
            UpdateTodoList();
            Session["MemberAuth"] = user;
        }

        /// <summary>
        /// Calls the PopulateWeather method and stores the value in the Session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WeatherButton_OnClick(object sender, EventArgs e)
        {
            var textValue = WeatherTextBox.Text;
            if (!String.IsNullOrEmpty(textValue))
            {
                PopulateWeather(textValue);
                Session["WeatherLocation"] = textValue;
            }
        }

        /// <summary>
        /// Populates the weather table
        /// </summary>
        /// <param name="location"></param>
        private void PopulateWeather(string location)
        {
            WeatherServiceClient client = new WeatherServiceClient();
            var weather = client.GetWeather(location);

            // Set the day of the week labels
            DateTime dt1 = Convert.ToDateTime(weather.DailyForecasts[0].Date);
            Day1Label.Text = dt1.ToString("dddd");
            DateTime dt2 = Convert.ToDateTime(weather.DailyForecasts[1].Date);
            Day2Label.Text = dt2.ToString("dddd");
            DateTime dt3 = Convert.ToDateTime(weather.DailyForecasts[2].Date);
            Day3Label.Text = dt3.ToString("dddd");
            DateTime dt4 = Convert.ToDateTime(weather.DailyForecasts[3].Date);
            Day4Label.Text = dt4.ToString("dddd");
            DateTime dt5 = Convert.ToDateTime(weather.DailyForecasts[4].Date);
            Day5Label.Text = dt5.ToString("dddd");

            // Set the weather images
            Image1.Text = ImageSelector(weather.DailyForecasts[0].Day.IconPhrase);
            Image2.Text = ImageSelector(weather.DailyForecasts[1].Day.IconPhrase);
            Image3.Text = ImageSelector(weather.DailyForecasts[2].Day.IconPhrase);
            Image4.Text = ImageSelector(weather.DailyForecasts[3].Day.IconPhrase);
            Image5.Text = ImageSelector(weather.DailyForecasts[4].Day.IconPhrase);

            // Set the weather description labels
            DescLabel1.Text = weather.DailyForecasts[0].Day.IconPhrase;
            DescLabel2.Text = weather.DailyForecasts[1].Day.IconPhrase;
            DescLabel3.Text = weather.DailyForecasts[2].Day.IconPhrase;
            DescLabel4.Text = weather.DailyForecasts[3].Day.IconPhrase;
            DescLabel5.Text = weather.DailyForecasts[4].Day.IconPhrase;

            // Set the maximum temperature labels
            MaxLabel1.Text = weather.DailyForecasts[0].Temperature.Maximum.Value + "°";
            MaxLabel2.Text = weather.DailyForecasts[1].Temperature.Maximum.Value + "°";
            MaxLabel3.Text = weather.DailyForecasts[2].Temperature.Maximum.Value + "°";
            MaxLabel4.Text = weather.DailyForecasts[3].Temperature.Maximum.Value + "°";
            MaxLabel5.Text = weather.DailyForecasts[4].Temperature.Maximum.Value + "°";

            // Set the minimum temperature value labels
            MinTemp1Label.Text = weather.DailyForecasts[0].Temperature.Minimum.Value + "°";
            MinTemp2Label.Text = weather.DailyForecasts[1].Temperature.Minimum.Value + "°";
            MinTemp3Label.Text = weather.DailyForecasts[2].Temperature.Minimum.Value + "°";
            MinTemp4Label.Text = weather.DailyForecasts[3].Temperature.Minimum.Value + "°";
            MinTemp5Label.Text = weather.DailyForecasts[4].Temperature.Minimum.Value + "°";

            HighLabel.Text = "High";
            LowLabel.Text = "Low";
        }

        /// <summary>
        /// Matches the description to the corresponding image
        /// </summary>
        /// <param name="description"></param>
        /// <returns>Returns the filepath to the corresponding image</returns>
        private string ImageSelector(string description)
        {
            if (description == "Partly sunny")
            {
                return "<img src='Images/partly sunny.png' />";
            }
            else if (description == "Mostly cloudy")
            {
                return "<img src='Images/cloudy.png' />";
            }
            else if (description == "Sunny")
            {
                return "<img src='Images/clear.png' />";
            }
            else if (description == "Partly sunny w/ t-storms")
            {
                return "<img src='Images/partly sunny.png' />";
            }
            else if (description.Contains("rain") || description.Contains("shower"))
            {
                return "<img src='Images/showers.png' />";
            }
            else if (description.Contains("cloud"))
            {
                return "<img src='Images/partly sunny.png' />";
            }
            else
            {
                return "<img src='Images/clear.png' />";
            }
        }

        /// <summary>
        /// Calls the AddItem method when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddItemButton_OnClick(object sender, EventArgs e)
        {
            AddItem();
        }

        /// <summary>
        /// Adds an item to the todoList
        /// </summary>
        private void AddItem()
        {
            DateTime date = new DateTime();
            TodoItem todo = new TodoItem();

            var userId = GetUserId(user);
            if (!userId.Equals("empty"))
            {
                todo.GlobalID = userId;
                todo.ListID = userId;
            }

            todo.ListLabel = "Todo List";
            todo.ListDateCreated = date.ToShortDateString();
            todo.ItemDateCreated = date.ToShortDateString();
            todo.ItemNotes = "None";
            todo.ItemLabel = AddItemTextBox.Text;
            todo.ItemDueDate = Request.Form["datepicker"];
            todo.ItemComplete = "false";
            todo.ItemID = Guid.NewGuid().ToString().ToUpper();

            TodolistServiceClient client = new TodolistServiceClient();
            client.AddTodoItem(todo);
            UpdateTodoList();
            AddItemTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Updates the todoList with fresh data
        /// </summary>
        private void UpdateTodoList()
        {
            TodoTable.Rows.Clear();
            CompleteTable.Rows.Clear();

            AuthServiceClient authClient = new AuthServiceClient();
            TodolistServiceClient client = new TodolistServiceClient();
            var list = client.GetTodoList();
            var authList = authClient.GetAuths();

            var userId = GetUserId(user);

            foreach (var item in list.TodoItem)
            {
                if (item.ItemComplete.Equals("false") && userId.Equals(item.GlobalID))
                {
                    TableRow row = new TableRow();

                    // Adds the To do item text
                    TableCell cell1 = new TableCell();
                    cell1.Text = item.ItemLabel;
                    cell1.Width = 400;
                    row.Cells.Add(cell1);

                    // Adds the To do item text
                    TableCell userCell = new TableCell();
                    userCell.Text = LookupUser(authList, item.GlobalID);
                    userCell.Width = 150;
                    row.Cells.Add(userCell);

                    // Adds the To do item text
                    TableCell dateCell = new TableCell();
                    dateCell.Text = item.ItemDueDate;
                    dateCell.Width = 100;
                    row.Cells.Add(dateCell);

                    // Adds the complete button
                    TableCell cell2 = new TableCell();
                    Button CompleteButton = new Button();
                    CompleteButton.Text = "Complete";
                    CompleteButton.ID = item.ItemID + "|Complete";
                    CompleteButton.ControlStyle.CssClass = "btn btn-primary btn - lg";
                    CompleteButton.Click += new EventHandler(this.TodoButtonCompleteEvent);
                    cell2.Controls.Add(CompleteButton);
                    row.Cells.Add(cell2);

                    // Add the delete button to the table
                    TableCell cell3 = new TableCell();
                    Button DeleteButton = new Button();
                    DeleteButton.Text = "Delete";
                    DeleteButton.ID = item.ItemID + "|Delete";
                    DeleteButton.ControlStyle.CssClass = "btn btn-primary btn - lg";
                    DeleteButton.Click += new EventHandler(this.TodoButtonDeleteEvent);
                    cell3.Controls.Add(DeleteButton);
                    row.Cells.Add(cell3);

                    TodoTable.Rows.Add(row);
                }
                else if(item.ItemComplete.Equals("true") && userId.Equals(item.GlobalID)) 
                {
                    TableRow row = new TableRow();

                    // Adds the To do item text
                    TableCell cell4 = new TableCell();
                    cell4.Text = item.ItemLabel;
                    cell4.Width = 400;
                    row.Cells.Add(cell4);

                    // Adds the To do item text
                    TableCell userCell = new TableCell();
                    userCell.Text = LookupUser(authList, item.GlobalID);
                    userCell.Width = 150;
                    row.Cells.Add(userCell);

                    // Adds the To do item text
                    TableCell dateCell = new TableCell();
                    dateCell.Text = item.ItemDueDate;
                    dateCell.Width = 100;
                    row.Cells.Add(dateCell);

                    // Adds the complete button
                    TableCell cell5 = new TableCell();
                    Button CompleteButton = new Button();
                    CompleteButton.Text = "Completed";
                    CompleteButton.ID = item.ItemID + "|Complete";
                    CompleteButton.ControlStyle.CssClass = "btn btn-primary btn - lg";
                    CompleteButton.ControlStyle.BorderColor = Color.Green;
                    CompleteButton.ControlStyle.BackColor = Color.Green;
                    cell5.Controls.Add(CompleteButton);
                    row.Cells.Add(cell5);

                    // Add the update button to the table
                    TableCell cell6 = new TableCell();
                    Button DeleteButton = new Button();
                    DeleteButton.Text = "Delete";
                    DeleteButton.ID = item.ItemID + "|Delete";
                    DeleteButton.ControlStyle.CssClass = "btn btn-primary btn - lg";
                    DeleteButton.Click += new EventHandler(this.TodoButtonDeleteEvent);
                    cell6.Controls.Add(DeleteButton);
                    row.Cells.Add(cell6);

                    CompleteTable.Rows.Add(row);
                }
            }
            if (list.TodoItem.Length == 0)
            {
                ActiveTasks.Visible = false;
                CompletedTasks.Visible = false;
            }
            else
            {
                ActiveTasks.Visible = true;
                CompletedTasks.Visible = true;
            }
        }

        /// <summary>
        /// Event Listener that fires when the corresponding complete button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TodoButtonCompleteEvent(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            char[] delimiterChars = { '|' };
            string[] text = clickedButton.ID.Split(delimiterChars);
            var itemId = text[0];

            TodolistServiceClient client = new TodolistServiceClient();
            var selectedItem = FindSelectedItem(itemId);
            if (!selectedItem.ItemLabel.Equals("empty"))
            {
                client.CompleteTodoItem(selectedItem);
                UpdateTodoList();
            }
        }

        /// <summary>
        /// Event Listener that fires when the corresponding delete button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TodoButtonDeleteEvent(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            char[] delimiterChars = { '|' };
            string[] text = clickedButton.ID.Split(delimiterChars);
            var itemId = text[0];

            TodolistServiceClient client = new TodolistServiceClient();
            var selectedItem = FindSelectedItem(itemId);
            if (!selectedItem.ItemLabel.Equals("empty"))
            {
                client.DeleteTodoItem(selectedItem);
                UpdateTodoList();
            }
        }

        /// <summary>
        /// Finds the TodoItem that corresponds the itemId
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>Returns the corresponding TodoItem</returns>
        private TodoItem FindSelectedItem(string itemId)
        {
            TodolistServiceClient client = new TodolistServiceClient();
            var list = client.GetTodoList();
            foreach (var item in list.TodoItem)
            {
                if (item.ItemID.Equals(itemId))
                {
                    return item;
                }
            }
            TodoItem emptyItem = new TodoItem();
            emptyItem.ItemLabel = "empty";
            return emptyItem;
        }

        /// <summary>
        /// Gets the userId of the specified username
        /// </summary>
        /// <param name="auths"></param>
        /// <param name="userId"></param>
        /// <returns>Returns the user's uid</returns>
        private string LookupUser(Auths auths, string userId)
        {
            foreach (var auth in auths.Auth)
            {
                if (auth.Uid.Equals(userId))
                {
                    return auth.Username;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the user id of the specified username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns the UID of the specified username</returns>
        private string GetUserId(string username)
        {
            AuthServiceClient client = new AuthServiceClient();
            var auths = client.GetAuths();
            foreach (var auth in auths.Auth)
            {
                if (auth.Username.Equals(username))
                {
                    return auth.Uid;
                }
            }
            return "empty";
        }
    }
}


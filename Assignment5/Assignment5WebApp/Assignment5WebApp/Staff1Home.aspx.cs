using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment5WebApp.AuthServiceReference;
using Assignment5WebApp.TodoListServiceReference;

namespace Assignment5WebApp
{
    public partial class Staff1Home : System.Web.UI.Page
    {
        private string user = "";

        /// <summary>
        /// Ensures that the user is authorized to access this page and updates the todoList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Staff1Auth"] != null)
            {
                user = (string)Session["Staff1Auth"];
                Staff1HomeLabel.Text = "Welcome " + user;

                if (!IsPostBack)
                {
                    Populate();
                }
            }
            else
            {
                Response.Redirect("Staff1.aspx");
            }
            UpdateTodoList();
            Session["Staff1Auth"] = user;
        }

        /// <summary>
        /// Calls AddItem when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddItemButton_OnClick(object sender, EventArgs e)
        {
            AddItem();
        }

        /// <summary>
        /// Adds the specified item for the specified user to the todolist
        /// </summary>
        private void AddItem()
        {
            if (AuthUserDropDown.SelectedValue.Equals("9999"))
            {
                AuthServiceClient authClient = new AuthServiceClient();
                TodolistServiceClient client = new TodolistServiceClient();
                DateTime date = new DateTime();
                var dueDate = Request.Form["datepicker"];
                var auths = authClient.GetAuths();
                foreach (var auth in auths.Auth)
                {
                    TodoItem todo = new TodoItem();
                    todo.GlobalID = auth.Uid;
                    todo.ListID = auth.Uid;
                    todo.ListLabel = "Todo List";
                    todo.ListDateCreated = date.ToShortDateString();
                    todo.ItemDateCreated = date.ToShortDateString();
                    todo.ItemNotes = "None";
                    todo.ItemLabel = AddItemTextBox.Text;
                    todo.ItemDueDate = dueDate;
                    todo.ItemComplete = "false";
                    todo.ItemID = Guid.NewGuid().ToString().ToUpper();
                    client.AddTodoItem(todo);
                }
                UpdateTodoList();
                AddItemTextBox.Text = string.Empty;
            }
            else
            {
                DateTime date = new DateTime();
                TodoItem todo = new TodoItem();
                todo.GlobalID = AuthUserDropDown.SelectedValue;
                todo.ListID = AuthUserDropDown.SelectedValue;
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
        }
        /// <summary>
        /// Popualtes the dropdown menus
        /// </summary>
        private void Populate()
        {
            AuthUserDropDown.Items.Clear();
            AuthServiceClient client = new AuthServiceClient();
            var auths = client.GetAuths();

            AuthUserDropDown.Items.Add(new ListItem("All Users", "9999"));
            foreach (var auth in auths.Auth)
            {
                AuthUserDropDown.Items.Add(new ListItem(auth.Username, auth.Uid));

            }
        }

        /// <summary>
        /// Updates the todolist table with fresh data
        /// </summary>
        private void UpdateTodoList()
        {
            TodoTable.Rows.Clear();
            CompleteTable.Rows.Clear();

            AuthServiceClient authClient = new AuthServiceClient();
            TodolistServiceClient client = new TodolistServiceClient();
            var list = client.GetTodoList();
            var authList = authClient.GetAuths();

            foreach (var item in list.TodoItem)
            {
                if (item.ItemComplete.Equals("false"))
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
                else
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
        /// Event that fires when the corresponding complete button is pressed
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
        /// Event that fires when the corresponding delete button is pressed
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
        /// Finds the selected item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>Returns the TodoItem that corresponds to the specified item id</returns>
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
        /// Looks up the specified user and returns their Uid
        /// </summary>
        /// <param name="auths"></param>
        /// <param name="userId"></param>
        /// <returns>Returns the user's UID</returns>
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
    }
}

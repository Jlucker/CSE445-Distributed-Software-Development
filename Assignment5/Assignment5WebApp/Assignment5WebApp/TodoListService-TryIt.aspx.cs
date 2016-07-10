using System;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment5WebApp.AuthServiceReference;
using Assignment5WebApp.TodoListServiceReference;

namespace Assignment5WebApp
{
    public partial class TodoListService_TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateTodoList();
                Populate();
            }
            UpdateTodoList();
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
        /// Adds the specified item to the specified user's list
        /// </summary>
        private void AddItem()
        {
            TodoItem todo = new TodoItem();
            todo.GlobalID = AuthUserDropDown.SelectedValue;
            todo.ListID = AuthUserDropDown.SelectedValue;
            todo.ListLabel = "Todo List";
            todo.ListDateCreated = "Today";
            todo.ItemDateCreated = "Today";
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
        /// Popualtes the user dropdown menu
        /// </summary>
        private void Populate()
        {
            AuthUserDropDown.Items.Clear();
            AuthServiceClient client = new AuthServiceClient();
            var auths = client.GetAuths();
           
            foreach (var auth in auths.Auth)
            {
                AuthUserDropDown.Items.Add(new ListItem(auth.Username, auth.Uid));
            }
        }

        /// <summary>
        /// Updates the todolist table with fresh data from the TodoData.xml doc
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
        /// Event receiver that fires when the corresponding complete button is clicked
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
        /// Event receiver that fires when the corresponding delete button is clicked
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
        /// <returns>Returns the TodoItem that corresponds to the specified itemId</returns>
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
        /// Looks up a user by their ID and returns their username
        /// </summary>
        /// <param name="auths"></param>
        /// <param name="userId"></param>
        /// <returns>Returns the specified user's username</returns>
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
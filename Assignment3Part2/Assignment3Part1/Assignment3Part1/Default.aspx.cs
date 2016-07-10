using System;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment3Part1.NewsServiceReference;
using Assignment3Part1.TodoServiceReference;
using Assignment3Part1.WeatherServiceReference;
using Microsoft.Ajax.Utilities;


namespace Assignment3Part1
{
    public partial class _Default : Page
    {
        private bool initial = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            //RestaurantTextBox.Text = "85281";
            UpdateTodoList();
          
        }

        protected void WeatherButton_OnClick(object sender, EventArgs e)
        {
            var textValue = WeatherTextBox.Text;
            if (!String.IsNullOrEmpty(textValue))
            {
                PopulateWeather();
            }
        }

        private void PopulateWeather()
        {
            string textValue = WeatherTextBox.Text;

            WeatherServiceClient client = new WeatherServiceClient();
            Weather weather = new Weather();

            // Check if the Weather text box is empty
            if (!String.IsNullOrEmpty(textValue))
            {
                weather = client.GetWeather(textValue);
            }

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

        // Selects the image best suited for the current weather conditions
        private string ImageSelector(string description)
        {
            if (description == "Partly sunny")
            {
                return "<img src='Images/partly sunny.png' />";
            }
            else if(description == "Mostly cloudy")
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
        

        protected void NewsButton_OnClick(object sender, EventArgs e)
        {
            var textValue = NewsTextBox.Text;
            if (!String.IsNullOrEmpty(textValue))
            {
                PopulateNews();
            }
        }

        private void PopulateNews()
        {
            string textValue = NewsTextBox.Text;

            NewsServiceClient client = new NewsServiceClient();
            NewsList newsList = new NewsList();

            char delimiterChar = ' ';
            string[] parts = textValue.Split(delimiterChar);

            if (!String.IsNullOrEmpty(textValue))
            {
                newsList = client.GetNews(textValue);
            }

            // Set the labels
            TopicLabel.Text = "Topic";
            TitleLabel.Text = "Title";

            var i = 0;
            foreach (var news in newsList.newsList)
            {
                var topic = parts[i];

                foreach (var item in news.Response.Results)
                {
                    TableRow row = new TableRow();

                    TableCell cell1 = new TableCell();
                    cell1.Text = topic;
                    row.Cells.Add(cell1);

                    TableCell cell2 = new TableCell();
                    HyperLink h1 = new HyperLink()
                    {
                        Text = item.WebTitle,
                        NavigateUrl = item.WebUrl
                    };
                    cell2.Controls.Add(h1);
                    row.Cells.Add(cell2);

                    NewsTable.Rows.Add(row);
                }
                i++;
            }
            NewsTable.Visible = true;
        }

        protected void TodoButton_OnClick(object sender, EventArgs e)
        {
            var text = TodoTextBox.Text;
            if (!string.IsNullOrEmpty(text))
            {
                TodoServiceClient client = new TodoServiceClient();
                client.AddTodoItem(text);
                UpdateTodoList();
            }
            TodoTextBox.Text = string.Empty;
        }

        private void UpdateTodoList()
        {
            TodoTable.Rows.Clear();
            CompleteTable.Rows.Clear();

            TodoServiceClient client = new TodoServiceClient();
            var list = client.GetToDoList();
            foreach (var item in list.todoList)
            {
                if (item.Complete == false)
                {
                    TableRow row = new TableRow();

                    // Adds the To do item text
                    TableCell cell1 = new TableCell();
                    cell1.Text = item.Title;
                    cell1.Width = 400;
                    row.Cells.Add(cell1);

                    // Adds the complete button
                    TableCell cell2 = new TableCell();
                    Button CompleteButton = new Button();
                    CompleteButton.Text = "Complete";
                    CompleteButton.ID = item.ItemId.ToString() + "|" + "complete";
                    CompleteButton.ControlStyle.CssClass = "btn btn-primary btn - lg";
                    CompleteButton.Click += new EventHandler(this.TodoButtonEvent);
                    cell2.Controls.Add(CompleteButton);
                    row.Cells.Add(cell2);

                    // Add the update button to the table
                    TableCell cell3 = new TableCell();
                    Button DeleteButton = new Button();
                    DeleteButton.Text = "Delete";
                    DeleteButton.ID = item.ItemId.ToString() + "|" + "delete";
                    DeleteButton.ControlStyle.CssClass = "btn btn-primary btn - lg";
                    DeleteButton.Click += new EventHandler(this.TodoButtonEvent);
                    cell3.Controls.Add(DeleteButton);
                    row.Cells.Add(cell3);

                    TodoTable.Rows.Add(row);
                }
                else
                {
                    TableRow row = new TableRow();

                    // Adds the To do item text
                    TableCell cell4 = new TableCell();
                    cell4.Text = item.Title;
                    cell4.Width = 400;
                    row.Cells.Add(cell4);

                    // Adds the complete button
                    TableCell cell5 = new TableCell();
                    Button CompleteButton = new Button();
                    CompleteButton.Text = "Completed";
                    CompleteButton.ID = item.ItemId.ToString() + "|" + "complete";
                    CompleteButton.ControlStyle.CssClass = "btn btn-primary btn - lg";
                    CompleteButton.ControlStyle.BorderColor = Color.Green;
                    CompleteButton.ControlStyle.BackColor = Color.Green;
                    cell5.Controls.Add(CompleteButton);
                    row.Cells.Add(cell5);

                    // Add the update button to the table
                    TableCell cell6 = new TableCell();
                    Button DeleteButton = new Button();
                    DeleteButton.Text = "Delete";
                    DeleteButton.ID = item.ItemId.ToString() + "|" + "delete";
                    DeleteButton.ControlStyle.CssClass = "btn btn-primary btn - lg";
                    DeleteButton.Click += new EventHandler(this.TodoButtonEvent);
                    cell6.Controls.Add(DeleteButton);
                    row.Cells.Add(cell6);

                    CompleteTable.Rows.Add(row);
                }
            }
            if (list.todoList.Length == 0)
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

        private void TodoButtonEvent(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            char[] delimiterChars = { '|'};
            string[] text = clickedButton.ID.Split(delimiterChars);
            var itemId = text[0];
            var operation = text[1];

            TodoServiceClient client = new TodoServiceClient();
            client.ModifyToDoItem(Guid.Parse(itemId), operation);
            UpdateTodoList();

        }

        protected void RestaurantButton_OnClick(object sender, EventArgs e)
        {
            
            var textValue = RestaurantTextBox.Text;
            GetRestaurants(textValue);
            
        }

        private void GetRestaurants(string textValue)
        {
            RestaurantApiClient client = new RestaurantApiClient();

            if (!string.IsNullOrEmpty(textValue) && !string.IsNullOrWhiteSpace(textValue))
            {
                RestaurantLabel.Text = "";
                RestaurantTextBox.Text = "";
                try
                {
                    var restaurants = client.Search(textValue);
                    PopulateRestaurants(restaurants);
                }
                catch (Exception)
                {
                    RestaurantLabel.Text = "Invalid address/zipcode";
                }
            }
            else
            {
                RestaurantLabel.Text = "Invalid address/zipcode";
            }
        }

        private void PopulateRestaurants(Restaurants restaurants)
        {
            DiningTable.Rows.Clear();

            TableRow rowA = new TableRow();

            TableCell cellA = new TableCell();
            cellA.Text = "";
            cellA.Width = 200;
            rowA.Cells.Add(cellA);

            TableCell cellB = new TableCell();
            cellB.Text = "Restaurant";
            cellB.Width = 250;
            cellB.HorizontalAlign = HorizontalAlign.Center;
            rowA.Cells.Add(cellB);

            TableCell cellC = new TableCell();
            cellC.Text = "Yelp Information";
            cellC.Width = 200;
            cellC.HorizontalAlign = HorizontalAlign.Center;
            rowA.Cells.Add(cellC);

            TableCell cellD = new TableCell();
            cellD.Text = "Zomato Information";
            cellD.Width = 200;
            cellD.HorizontalAlign = HorizontalAlign.Center;
            rowA.Cells.Add(cellD);

            TableCell cellE = new TableCell();
            cellE.Text = "Price Range";
            cellE.Width = 200;
            cellE.HorizontalAlign = HorizontalAlign.Center;
            rowA.Cells.Add(cellE);

            DiningTable.Rows.Add(rowA);

            foreach (var r in restaurants.restaurants)
            {
                TableRow row = new TableRow();
                TableCell cell0 = new TableCell();
                if (string.IsNullOrEmpty(r.RestaurantImageUrl))
                {
                    cell0.Text = "<img src='Images/confused.gif' width=\"200\" height =\"100\"/>";
                }
                else
                {
                    cell0.Text = string.Format("<img src='" + r.RestaurantImageUrl + "' width=\"200\" height =\"100\"/>");
                }
                
                cell0.Width = 200;
                row.Cells.Add(cell0);


                TableCell cell1 = new TableCell();
                StringBuilder table0 = new StringBuilder();
                table0.Append("<table><tr><td align=\"center\">");
                table0.Append(r.RestaurantName);
                table0.Append("</td></tr>");
                table0.Append("<tr><td align=\"center\">");
                table0.Append("<a href=\"https://www.google.com/maps/place/");
                table0.Append(r.RestaurantAddress);
                table0.Append("\" target=\"blank\">");
                table0.Append("Get Directions");
                table0.Append("</a>");
                table0.Append("</td></tr>");
                table0.Append("</table>");
                cell1.Text = table0.ToString();
                cell1.Width = 250;
                cell1.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                StringBuilder table1 = new StringBuilder();

                if (r.ContainsBoth == "true")
                {
                    table1.Append("<table><tr><td align=\"center\"><img src='");
                    table1.Append(r.YelpRatingImageUrl);
                    table1.Append("'/></td></tr> ");
                    table1.Append("<tr><td align=\"center\">");
                    table1.Append("<a href=\"");
                    table1.Append(r.YelpUrl);
                    table1.Append("\" target=\"blank\">See it on Yelp!</a>");
                    table1.Append("</tr></td>");
                    table1.Append("</table>");
                    cell2.Text = table1.ToString();
                    cell2.Width = 200;
                    cell2.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell2);
                    
                }
                else
                {
                    cell2.Text = "No Yelp Data";
                    cell2.Width = 200;
                    cell2.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell2);
                }
                

                TableCell cell3= new TableCell();
                StringBuilder table2 = new StringBuilder();

                table2.Append("<table><tr><td align=\"center\">");
                table2.Append(r.ZomatoRating);
                table2.Append("</td></tr>");
                table2.Append("<tr><td align=\"center\">");
                table2.Append("<a href=\"");
                table2.Append(r.ZomatoUrl);
                table2.Append("\" target=\"blank\">See it on Zomato!</a>");
                table2.Append("</tr></td>");
                table2.Append("</table>");
                cell3.Text = table2.ToString();
                cell3.Width = 200;
                cell3.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell3);

                StringBuilder table3 = new StringBuilder();
                TableCell cell4 = new TableCell();
                if (r.RestaurantPrice == "1")
                {
                    cell4.Text = "<img src = 'Images/one.png' width=\"100\" height =\"50\"/>";
                }
                else if (r.RestaurantPrice == "2")
                {
                    cell4.Text = "<img src = 'Images/two.png' width=\"100\" height =\"50\"/>";
                }
                else if (r.RestaurantPrice == "3")
                {
                    cell4.Text = "<img src = 'Images/three.png' width=\"100\" height =\"50\"/>";
                }
                else
                {
                    cell4.Text = "<img src = 'Images/four.png' width=\"100\" height =\"50\"/>";
                }
                cell4.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell4);
                DiningTable.Rows.Add(row);



            }
        }
    }
}
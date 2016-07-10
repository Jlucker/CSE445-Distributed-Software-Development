//****************************************************************************************
// Name:        Justin Lucker
// ASUID:       1205448942
// Assignment:  Assignment 1 part 3
// Description: A web app that consumes the temperature service from part 1
//****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TemperatureWebApp.ServiceReference1;

namespace TemperatureWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            c2fLabel.Text = "";
            f2cLabel.Text = "";
        }

        protected void c2fConvertButton_OnClick(object sender, EventArgs e)
        {
            int value;
            // Check if the textbox contains an integer value
            if (!int.TryParse(c2fTextBox.Text, out value))
            {
                c2fLabel.Text = "Please enter an integer";
                return;
            }
            // Attempts to access the temperature service
            try
            {
                // Success! The conversion is performed and displayed
                Service1Client service = new Service1Client();
                var result = service.c2f(value).ToString();
                c2fLabel.Text = value + "°C = " + result + "°F";
            }
            catch (Exception)
            {
                // Failure! This message is displayed
                c2fLabel.Text = "Please run the corresponding service";
            }
        }

        protected void f2cConvertButton_OnClick(object sender, EventArgs e)
        {
            int value;
            // Check if the textbox contains an integer value
            if (!int.TryParse(f2cTextBox.Text, out value))
            {
                f2cLabel.Text = "Please enter an integer";
                return;
            }
            // Attempts to access the temperature service
            try
            {
                // Success! The conversion is performed and displayed
                Service1Client service = new Service1Client();
                var result = service.f2c(value).ToString();
                f2cLabel.Text = value + "°F = " + result + "°C";
            }
            catch (Exception)
            {
                // Failure! This message is displayed
                f2cLabel.Text = "Please run the corresponding service";
            }
        }
    }
}
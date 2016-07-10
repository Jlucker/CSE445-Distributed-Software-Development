//****************************************************************************************
// Name:        Justin Lucker
// ASUID:       1205448942
// Assignment:  Assignment 1 part 2
// Description: A WPF app that consumes the temperature service from part 1
//****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TemperatureForm.ServiceReference1;

namespace TemperatureForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cResultLabel.Content = "";
            fResultLabel.Content = "";
        }

        // Converts the entered celsius value to fahrenheit when clicked
        private void convertc2fButton_Click(object sender, RoutedEventArgs e)
        {
            int value;
            // Check if the textbox contains an integer value
            if (!int.TryParse(c2fTextBox.Text , out value))
            {
                MessageBox.Show("Please enter an integer");
                return;
            }
            // Attempts to access the temperature service
            try
            {
                // Success! The conversion is performed and displayed
                Service1Client service = new Service1Client();
                var result = service.c2f(value).ToString();
                cResultLabel.Content = value + "°C = " + result + "°F";
            }
            catch (Exception)
            {
                // Failure! This message is displayed
                MessageBox.Show("Please run the corresponding service");
                return;
            }
        }

        // Converts the entered fahrenheit value to celsius when clicked
        private void convertf2cButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            int value;
            // Check if the textbox contains an integer value
            if (!int.TryParse(f2cTextBox.Text, out value))
            {
                MessageBox.Show("Please enter an integer");
                return;
            }
            // Attempts to access the temperature service
            try
            {
                // Success! The conversion is performed and displayed
                Service1Client service = new Service1Client();
                var result = service.f2c(value).ToString();
                fResultLabel.Content = value + "°F = " + result + "°C";
            }
            catch (Exception)
            {
                // Failure! This message is displayed
                MessageBox.Show("Please run the corresponding service");
                return;
            }
        }
    }
}

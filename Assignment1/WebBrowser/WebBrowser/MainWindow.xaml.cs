//****************************************************************************************
// Name:        Justin Lucker
// ASUID:       1205448942
// Assignment:  Assignment 1 part 4, 5, and 6
// Description: A simple web browser with widgets at the bottom 
//****************************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WebBrowser.EncryptDecryptService;
using WebBrowser.StockQuoteService;

namespace WebBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Set the default web page
            webBrowser.Navigate("http://google.com");
            urlTextBox.Text = "http://google.com";

            // Populate the stock search box for easy testing
            stockTextBox.Text = "GOOG, IBM, AHC, ATEN, AAON, AAN, ABAX, ABB, CH, FCO, ABMD";
            sendButton.IsEnabled = false;
        }

        // Directs the web browser to the webpage that is entered
        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            // Checks if the input is null or empty before navigating
            // Sends the user to a default web page if empty
            if (!String.IsNullOrEmpty(urlTextBox.Text))
            {
                webBrowser.Navigate(urlTextBox.Text);
            }
            else
            {
                urlTextBox.Text = "http://google.com";
                webBrowser.Navigate("http://google.com");
            }
        }

        // Uses the provided service to access stock quotes
        private void stockButton_Click(object sender, RoutedEventArgs e)
        {
            // Checks if the input is null or empty before calling the service
            if (!String.IsNullOrEmpty(stockTextBox.Text))
            {
                // Specifying the characters that will be used to split the entered stock
                // symbols and the results from the service
                char[] separatingChars = { '\n', ',' };

                // Using a list of type StockData to keep everything tidy
                List<StockData> stockData = new List<StockData>();

                // Splits the stock symbols by commas
                string[] symbols = stockTextBox.Text.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
                
                // Creates new client object for the stock quote service
                StockQuoteService.ServiceClient stock = new StockQuoteService.ServiceClient();

                // Calls the stock quoate service
                var stockResult = stock.getStockquote(stockTextBox.Text);

                // splits the stock values by the \n operator
                string[] values = stockResult.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);

                var index = 0;
                var result = "";

                // Populates and refines the data received from the user and the service
                foreach (var s in symbols)
                {
                    StockData data = new StockData();
                    data.stockSymbol = s.Replace(" ", "");
                    data.stockValue = values[index].Replace(" ", "");
                    stockData.Add(data);
                    result += data.stockSymbol + " \t" + data.stockValue + " \t USD\n";
                    index++;
                }
                stockResultTextBox.Text = result;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            stockResultTextBox.Text = "";
            stockTextBox.Text = "";
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            // Checks if the input is null or empty before calling the service
            if (!String.IsNullOrEmpty(encryptTextBox.Text))
            {
                EncryptDecryptService.ServiceClient encryptDecrypt = new EncryptDecryptService.ServiceClient();
                encryptedResultTextBox.Text = encryptDecrypt.Encrypt(encryptTextBox.Text);
                sendButton.IsEnabled = true;
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            EncryptDecryptService.ServiceClient encryptDecrypt = new EncryptDecryptService.ServiceClient();
            encryptedResultTextBox.Text = encryptDecrypt.Decrypt(encryptedResultTextBox.Text);
            sendButton.IsEnabled = false;
        }

        private void clearEncryptButton_Click(object sender, RoutedEventArgs e)
        {
            encryptedResultTextBox.Text = "";
            encryptTextBox.Text = "";
            sendButton.IsEnabled = false;
        }
    }
}

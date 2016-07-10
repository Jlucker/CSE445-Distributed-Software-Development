//****************************************************************************************
// Name:        Justin Lucker
// ASUID:       1205448942
// Assignment:  Assignment 2
// Description: A simple ecommerce system
//****************************************************************************************
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Order
    {
        private string senderId;
        private int amount;
        private string cardNumber;
        private double price;
        private string uniqueId = "";

        // Default values of order
        public Order()
        {
            senderId = "";
            amount = 0;
            cardNumber = "";
            price = 0.0;
            uniqueId = System.Guid.NewGuid().ToString().ToUpper();
        }
        public string getSenderId()
        {
            return senderId;
        }

        public void setSenderId(string id)
        {
            senderId = id;
        }

        public int getAmount()
        {
            return amount;
        }

        public void setAmount(int am)
        {
            amount = am;
        }

        public string getCardNumber()
        {
            return cardNumber;
        }

        public void setCardNumber(string num)
        {
            cardNumber = num;
        }

        public double getPrice()
        {
            return price;
        }

        public void setPrice(double pr)
        {
            price = pr;
        }
        public string getUniqueId()
        {
            return uniqueId;
        }
        public void setUniqueId(string uid)
        {
            uniqueId = uid;
        }
    }
}

//****************************************************************************************
// Name:        Justin Lucker
// ASUID:       1205448942
// Assignment:  Assignment 2
// Description: A simple ecommerce system
//****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment2
{
    class Decoder
    {
        private Order order = new Order();

        // Converts the message string into an order object
        public Order Decode(string message)
        {
            if (!message.Equals("empty"))
            {
                char delimiterChar = '|';
                string[] parts = message.Split(delimiterChar);
                order.setSenderId(parts[0]);
                order.setAmount(Convert.ToInt32(parts[1]));
                order.setCardNumber(parts[2]);
                order.setUniqueId(parts[3]);

                return order;
            }
            else
            {
                return order;
            }
        }
    }
}

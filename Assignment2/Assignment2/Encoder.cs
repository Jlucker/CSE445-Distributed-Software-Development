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
    class Encoder
    {
        private string message = "";

        public string Encode(Order order)
        {
            // Checks if the senderId is null or empty
            if (!String.IsNullOrEmpty(order.getSenderId()))
            {
                message += order.getSenderId();
                message += "|";
            }
            else
            {
                message += "n/a";
                message += "|";
            }

            // The order amount will always be at least 0
            message += order.getAmount();
            message += "|";

            // Checks if the cardNumber is null or empty
            if (!String.IsNullOrEmpty(order.getCardNumber()))
            {
                message += order.getCardNumber();
                message += "|";
            }
            else
            {
                message += "0000000000000000";
                message += "|";
            }
            // Checks if the uniqueId is null or empty
            if (!String.IsNullOrEmpty(order.getUniqueId()))
            {
                message += order.getUniqueId();
            }
            else
            {
                message += "None";
            }
            return message;
        }
    }
}

//****************************************************************************************
// Name:        Justin Lucker
// ASUID:       1205448942
// Assignment:  Assignment 2
// Description: A simple ecommerce system
//****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Web;

namespace Assignment2
{
    // Define a delegate
    public delegate void priceCutEvent(Int32 pr);
    public delegate void OrderCompleteEvent(Order order);
    public class ChickenFarm
    {
        // Generates random numbers
        static Random rng = new Random();

        // Link event to delegate
        public static event priceCutEvent priceCut;
        public static event OrderCompleteEvent orderComplete;
        private static Int32 chickenPrice = 10;


        public static Int32 getPrice()
        {
            return chickenPrice;
        }
        public static void changePrice(Int32 price)
        {
            // If the price is lower than the current chicken price
            if (price < chickenPrice)
            {
                // And there is at least 1 subscriber
                if (priceCut != null)
                {
                    // Emit a pricecut event to subscribers
                    chickenPrice = price;
                    priceCut(price);
                }
            }
        }
        public void farmerFunc()
        {
            for (Int32 i = 0; i < 50; i++)
            {

                Thread.Sleep(500);
                // Take the order from the queue of the orders
                // Decide the price based on the orders
                Thread getOrder = new Thread(new ThreadStart(GetOrder));
                getOrder.Start();
                Console.WriteLine("New Farm Price is ${0}", getPrice());
            }
        }

        public void GetOrder()
        {
            var encodedOrder = Program.mcb.getOneCell();
            Decoder decoder = new Decoder();
            OrderProcessing op = new OrderProcessing();
            op.order = decoder.Decode(encodedOrder);
         
            if (op.order.getSenderId() != "empty" && !String.IsNullOrEmpty(op.order.getSenderId()))
            {
                if (Program.verbose == 1)
                {
                    Console.WriteLine("Order From: Store " + op.order.getSenderId() + " Has been Received!");
                }
                var temp = op.ProcessOrder();
                orderComplete(temp);
                PricingModel();
            }
            else
            {
                PricingModel();
            }
        }

        public void PricingModel()
        {
            var rand = rng.Next(1, 100);
            // if rand%2 is 0 the price goes up
            if (rand%2 == 0)
            {
                if (chickenPrice > 10)
                {
                    changePrice(9);
                }
                else
                {
                    changePrice(chickenPrice + rng.Next(1, 3));
                }
            }
            // if rand%2 is 1 the price goes down
            else
            {
                if (chickenPrice > 3)
                {
                    changePrice(chickenPrice - rng.Next(1, 3));
                }
                else
                {
                    changePrice(chickenPrice += rng.Next(1, 3));
                }
            }
        }
    }
}
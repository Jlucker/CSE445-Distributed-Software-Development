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
using System.Threading;
using System.Threading.Tasks;
namespace Assignment2
{
    public class Retailer
    {
       // Generates random numbers
        private Random rng = new Random();

        public string cardNumber = "";
        public string retailerName = "";
        public double totalSpent;

        public List<Order> ordersInProgress = new List<Order>();
        public List<Order> ordersComplete = new List<Order>();
           
        public void retailerFunc()
        {
            retailerName = Thread.CurrentThread.Name;
            //ChickenFarm chicken = new ChickenFarm();
            for (Int32 i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Int32 p = ChickenFarm.getPrice();
                // Thread.CurrentThread.Name prints the thread name
                //orderChickens();
                Console.WriteLine("Store {0} has everyday low price: ${1} each", retailerName, p);
            }
        }
        // Event Handler
        public void chickenOnSale(Int32 p)
        {
            // Order chickens from chicken farm - send order into queue
            orderChickens();
            Console.WriteLine("Store {0} chickens are on sale: as low as ${1} each", retailerName, p);
        }

        // This method is called when the Chicken Farm completes an order
        public void OrderComplete(Order order)
        {
            for (int i = 0; i < ordersInProgress.Count; i++)
            {
                if (ordersInProgress.ElementAt(i).getUniqueId() == order.getUniqueId())
                {
                    Order tempOrder = new Order();
                    tempOrder.setUniqueId(ordersInProgress.ElementAt(i).getUniqueId());
                    tempOrder.setSenderId(ordersInProgress.ElementAt(i).getSenderId());
                    tempOrder.setAmount(ordersInProgress.ElementAt(i).getAmount());
                    tempOrder.setCardNumber(ordersInProgress.ElementAt(i).getCardNumber());
                    tempOrder.setPrice(ordersInProgress.ElementAt(i).getPrice());

                    ordersComplete.Add(tempOrder);
                    Console.WriteLine("Store " + retailerName + " Completed order: " + ordersInProgress.ElementAt(i).getUniqueId());
                    ordersInProgress.RemoveAt(i);
                    break;
                }
            }
            TotalSpent();
        }


        // Counts the orders and adds up the total amount spent
        public void TotalSpent()
        {
            var tempTotal = 0.0;

            foreach (var order in ordersComplete)
            {
                tempTotal += order.getPrice();
            }
            totalSpent = tempTotal;

            Console.WriteLine("Store " + retailerName + " order completed count " + ordersComplete.Count + " so far.");
        }

        public void orderChickens()
        {
            if (Program.verbose == 1)
            {
                Console.WriteLine("Store: " + retailerName + " is placing an order!");
            }
            Order order = new Order();
            //order.setSenderId(Thread.CurrentThread.Name);
            order.setSenderId(retailerName);
            order.setAmount(rng.Next(5,10));
            order.setCardNumber(cardNumber);

            ordersInProgress.Add(order);

            Encoder encoder = new Encoder();
            var message = encoder.Encode(order);

            // Send an order to the multicell buffer
            Program.mcb.setOneCell(message);
            if (Program.verbose == 1)
            {
                Console.WriteLine("Store: " + order.getSenderId() + " added an order to the MCB");
            }
        }
    }
}

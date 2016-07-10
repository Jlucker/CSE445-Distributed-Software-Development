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
    class Program
    {
        // Set to 1 for verbose Details
        public static int verbose = 1;

        public static MultiCellBuffer mcb = new MultiCellBuffer();

        static void Main(string[] args)
        {

            ChickenFarm chicken = new ChickenFarm();
            Thread farmer = new Thread(new ThreadStart(chicken.farmerFunc));

            // Start one Farmer Thread
            farmer.Start();

            // Array of retailer threads
            Thread[] retailers = new Thread[5];

            //  Declaring the 5 retailers
            Retailer chickenstore1 = new Retailer();
            chickenstore1.cardNumber = "3782822463100051";
            ChickenFarm.priceCut += new priceCutEvent(chickenstore1.chickenOnSale);
            ChickenFarm.orderComplete += new OrderCompleteEvent(chickenstore1.OrderComplete);
            retailers[0] = new Thread(new ThreadStart(chickenstore1.retailerFunc));
            retailers[0].Name = (1).ToString();
        
            Retailer chickenstore2 = new Retailer();
            chickenstore2.cardNumber = "3714496353984312";
            ChickenFarm.priceCut += new priceCutEvent(chickenstore2.chickenOnSale);
            ChickenFarm.orderComplete += new OrderCompleteEvent(chickenstore2.OrderComplete);
            retailers[1] = new Thread(new ThreadStart(chickenstore2.retailerFunc));
            retailers[1].Name = (2).ToString();
          
            Retailer chickenstore3 = new Retailer();
            chickenstore3.cardNumber = "4111111111111111";
            ChickenFarm.priceCut += new priceCutEvent(chickenstore3.chickenOnSale);
            ChickenFarm.orderComplete += new OrderCompleteEvent(chickenstore3.OrderComplete);
            retailers[2] = new Thread(new ThreadStart(chickenstore3.retailerFunc));
            retailers[2].Name = (3).ToString();
          
            Retailer chickenstore4 = new Retailer();
            chickenstore4.cardNumber = "4012888888881881";
            ChickenFarm.priceCut += new priceCutEvent(chickenstore4.chickenOnSale);
            ChickenFarm.orderComplete += new OrderCompleteEvent(chickenstore4.OrderComplete);
            retailers[3] = new Thread(new ThreadStart(chickenstore4.retailerFunc));
            retailers[3].Name = (4).ToString();
          
            Retailer chickenstore5 = new Retailer();
            chickenstore5.cardNumber = "3787344936710002";
            ChickenFarm.priceCut += new priceCutEvent(chickenstore5.chickenOnSale);
            ChickenFarm.orderComplete += new OrderCompleteEvent(chickenstore5.OrderComplete);
            retailers[4] = new Thread(new ThreadStart(chickenstore5.retailerFunc));
            retailers[4].Name = (5).ToString();
           
            for (int i = 0; i < retailers.Length; i++)
            {
                retailers[i].Start();
            }
        }
    }
}

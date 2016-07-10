using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2
{
    public class MultiCellBuffer
    {
        public Semaphore semaphore = new Semaphore(5,5);
        private string[] mcb = new string[5];

        public MultiCellBuffer()
        {
            // Initialize the array and the semaphore
            for (int i = 0; i < mcb.Length; i++)
            {
                mcb[i] = String.Empty;
            }
        }

        public string getOneCell()
        {
            if (Program.verbose == 1)
            {
                Console.WriteLine("Get One Cell Has been Called");
            }
           
            for (int i = 0; i < mcb.Length; i++)
            {
                if (mcb[i] != String.Empty)
                {
                    var value = mcb[i];
                    mcb[i] = String.Empty;
                    DisplayCellContents();
                    semaphore.Release(1);
                    return value;
                }
            }
            return "empty";
        }

        private void DisplayCellContents()
        {
            for (int i = 0; i < mcb.Length; i++)
            {
                if (Program.verbose == 1)
                {
                    Console.WriteLine("Contents of Cell: " + i + " is " + mcb[i]);
                }
            }
        }
        public void setOneCell(string order)
        {
            if (Program.verbose == 1)
            {
                Console.WriteLine("setOneCell has been called");
            }
           
            semaphore.WaitOne();

            for (int i = 0; i < mcb.Length; i++)
            {
                if (mcb[i] == String.Empty)
                {
                    lock (mcb[i])
                    {
                        mcb[i] = order;
                        
                        
                    }
                    DisplayCellContents();
                    break;
                }
            }
        }
    }
}

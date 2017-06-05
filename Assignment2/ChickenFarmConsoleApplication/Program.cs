using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChickenFarmConsoleApplication
{
    class Program
    {
        /*
         * Attributes required to initiate the chicken farm e-commerce application
         */ 
        private static ChickenFarm chickenFarm;
        private static Int32 retailersCount;
        private static Thread farmer;
        private static Thread[] retailers;
        private static Retailer[] chickenStores;

        public Program()
        {
            chickenFarm = new ChickenFarm();
            retailersCount = 0;
        }

        private void setNumberofRetailers()
        {
            /*
             * Function to initialize all attributes and kick off the threads
             */ 
            try
            {
                retailersCount = Convert.ToInt32(Console.ReadLine());
                farmer = new Thread(new ThreadStart(chickenFarm.farmerFunc));
                Console.WriteLine("  ____________________________________________________________________________");
                Console.WriteLine("                       Chicken Sale kick-off by Main Thread                 ");
                Console.WriteLine("  ____________________________________________________________________________");
                farmer.Start();

                retailers = new Thread[retailersCount];
                chickenStores = new Retailer[retailersCount];
            }
            
            catch(Exception e)
            {
                Console.Write("Number of retailers : ");
                setNumberofRetailers();
            } 
        }

        /*
         * Driver progran to initiate all threads 
         */ 
        static void Main(string[] args)
        {
            Program program = new Program();
            
            /*
             * Get the number of retailers using command line input
             */ 
            Console.Write("Number of retailers : ");
            program.setNumberofRetailers();

            /*
             * iterate through the loop until either thread dies or
             * number of retailers count reaches maximum
             */ 
            int i = 0;
            while(i < retailersCount && farmer.IsAlive)
            {
                chickenStores[i] = new Retailer(i + 1);
                /*
                 * Subscribing all the retailers to the priceCut event
                 */ 
                ChickenFarm.priceCut += new ChickenFarm.priceCutEvent(chickenStores[i].chickenOnSale);
                /*
                 * Initiating all the retailer threads
                 */
                retailers[i] = new Thread(new ThreadStart(chickenStores[i].retailerFunc));
                retailers[i].Name = (i + 1).ToString();
                retailers[i].Start();
                i += 1; 
            }
        }
    }
}

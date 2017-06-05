using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChickenFarmConsoleApplication
{
    /*
     * PriceModel - A class to determine the price of the chicken 
     * based on the current availability of the chicken
     */ 
    class PriceModel
    {
        private ReaderWriterLock rwl;
        private Random random;
        private static Int32 newPrice;

        public PriceModel()
        {
            random = new Random();
            rwl = new ReaderWriterLock();
            newPrice = 0;
        }

        /*
         * Method to acquire and release lock using ReaderWriterLock
         */ 
        private void acquireLock()
        {
            rwl.AcquireWriterLock(Timeout.Infinite);
        }

        private void releaseLock()
        {
            rwl.ReleaseWriterLock();
        }

        /*
         * This method retrieves the price of the chicken based on the availability
         */ 
        public int retrieveNewPrice()
        {
            acquireLock();
            try
            {
                ChickenFarm chickenFarm = new ChickenFarm();
                int currentAvailability = chickenFarm.currentChickenAvailability();

                /*
                 * Divide the total number of chickens into 5 intervals
                 */ 
                int priceRange = currentAvailability/5;

                /*
                 * Calculate the range of the available chickens 
                 */
                int priceForSwitchCase = (priceRange == 0 ) ? currentAvailability : (currentAvailability / priceRange);
                switch (priceForSwitchCase)
                {
                    /*
                     * Assign cost based on the value of the range
                     */ 
                    case (0): //[0,20]
                        {
                            newPrice = random.Next(15, 20);
                        }
                        break;
                    case (1): //[20,40]
                        {
                            newPrice = random.Next(20, 25);
                        }
                        break;
                    case (2): //[40,60]
                        {
                            newPrice = random.Next(25, 30);
                        }
                        break;
                    case (3): //[60,80]
                        {
                            newPrice = random.Next(30, 35);
                        }
                        break;
                    case (4): //[80,100]
                    case (5): //[80,100]
                        {
                            newPrice = random.Next(35, 40);
                        }
                        break;
                    default: break;
                }

                return newPrice;
            }
            finally
            {
                releaseLock();
            }
        }
    }
}

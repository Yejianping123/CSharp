using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChickenFarmConsoleApplication
{
    /*
     * A class to maintain the chicken farm server the notify the ratailers about
     * change in price.
     */ 
    class ChickenFarm
    {
        public static Int32 chickensPurchased;
        public static Int32 eventCount;
        /*
         * A event handler and delegate to handle the price cut event 
         */
        public delegate void priceCutEvent(Int32 oldPrice, Int32 price, Int32 availability, int drop);
        public static event priceCutEvent priceCut;
        
        ReaderWriterLock rwl = new ReaderWriterLock();
        Retailer chickenStore = new Retailer();
        /*
         * Initialize chicken price to $40
         * total chicken available for purchase is 100
         * maximum number of event cut to be performed to 10
         */
        public static Int32 chickenPrice = 40;
        public const Int32 totalChickenCount = 100;
        public const Int32 totalEventCount = 10;
 
        /*
         * Methods to acquire and release locks
         */
        public void acquireLock()
        {
            rwl.AcquireWriterLock(Timeout.Infinite);
        }

        public void releaseLock()
        {
            rwl.ReleaseWriterLock();
        }

        /*
         * Method to return the chicken price
         */ 
        public int getPrice()
        {
            return chickenPrice;
        }

        /*
         * Method to check the current chicken availability
         */ 
        public int currentChickenAvailability()
        {
           return totalChickenCount - chickensPurchased;
        }


        public void incrementPriceCutEvent()
        {
            eventCount += 1;
        }
        /*
         * Method to cut price which was randomly decided by the Pricing Model
         * based on the chicken availability
         */
        public void dropPrice()
        {
            PriceModel pricingModel = new PriceModel();
            Int32 price = pricingModel.retrieveNewPrice();
            
            ReaderWriterLock rwl = new ReaderWriterLock();
            Int32 ordersAvailable = currentChickenAvailability();
            Int32 reducedPrice;

            Console.WriteLine("\tChickenFarm : New chicken Price from price model is {0}", price);

            /*
             * trigger the price cut event 
             * if the chicken price is reduced from the old price
             */ 
            if (price <= chickenPrice)
            {              
                /*
                 * Run only if there is atleast one subscriber to the event
                 */ 
                if (priceCut != null)
                {
                    try
                    {
                        acquireLock();
                        /*
                         * Notify retailers about the reduced change in price 
                         */
                        reducedPrice = chickenPrice - price;
                        priceCut(chickenPrice, price, ordersAvailable, reducedPrice);
                    }

                    finally
                    {
                        releaseLock();
                    }
                }

                else
                {
                    Console.WriteLine("\tThere were no subscribers for the event");
                }

                chickenPrice = price;
                incrementPriceCutEvent();
            }
        }

        /*
         * Method to check if the total number of price cut is 
         * less than 10
         */ 
        public Boolean eventNotFinished()
        {
            return (totalEventCount - eventCount > 0);
        }

        /*
         * A function to trigger the drop price as far as the event is still alive
         * and the chickens are not yet sold.
         */ 
        public void farmerFunc()
        {
            while ((currentChickenAvailability() > 0) && eventNotFinished())
            {
                Thread.Sleep(500);
                dropPrice();
            }
            Console.WriteLine("  ____________________________________________________________________________");
            Console.WriteLine("                              End of Chicken Sale                            ");
            Console.WriteLine("  ____________________________________________________________________________");
        }
    }
}

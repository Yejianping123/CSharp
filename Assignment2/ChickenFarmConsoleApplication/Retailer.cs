using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChickenFarmConsoleApplication
{
    /*
     * A class for Retailers or chicken store.
     */ 
    class Retailer
    {
        public int threadID;

        public Retailer(int threadID)
        {
            this.threadID = threadID;
        }

        /*
         * Methods to acquire and release ReaderWriterLock
         */
        public void acquireLock(ReaderWriterLock rwl)
        {
            rwl.AcquireWriterLock(Timeout.Infinite);
        }

        public void releaseLock(ReaderWriterLock rwl)
        {
            rwl.ReleaseWriterLock();
        }


        public Retailer()
        {
            this.threadID = 0;
        }

        /*
         * initiate a retailer thread
         */
        public void retailerFunc()
        {
            Retailer retailer = new Retailer(threadID);
            ChickenFarm chicken = new ChickenFarm();
            Thread.Sleep(500);
            Int32 p = chicken.getPrice();
            Console.WriteLine("\tStore{0} current price: ${1} each", Thread.CurrentThread.Name, p);
        }


        /*
         * A callback method to notify about the order confirmation 
         * and notify about the remaining chickens
         * 
         */
        public void orderConfirmationCallBack(Int32 threadId, Int32 maxLimit)
        {
            Console.WriteLine("Order successful");
            Console.WriteLine("   Chicken Availability Status : {0}", maxLimit);
        }

        /*
         * Methods to generate random order and card numbers.
         */
        public Int32 generateRandomOrderNo(Random random)
        {
            return random.Next(1000, 2000);
        }

        public Int32 generateRandomCardNo(Random random)
        {
            return random.Next(5000, 7000);
        }

        /*
         * A function to set value to respective attributes in the order class
         */ 
        public Order setOrderObject(Int32 threadID, int price, Int32 availableChickens, Int32 priceDrop)
        {
            Random random = new Random();
            Int32 cardNo = generateRandomCardNo(random);
            Int32 orderNo = generateRandomOrderNo(random);
            Int32 amount = chickensToPurchase(random, availableChickens, priceDrop);

            Order order = new Order();
            order.OrderNo = orderNo;
            order.SenderID = threadID;
            order.CardNo = cardNo;
            order.Amount = amount;
            order.SellingPrice = price;
            return order;
        }

        /*
         * A function to decide the chickens to purchase based on the 
         * price dropped by the chickenFarm.
         * More the price drop, more is the purchase
         */ 
        public Int32 chickensToPurchase(Random random,int availableChickens,int priceDrop)
        {
            /*
             * Apply only if the available chickens is greater than 5
             */ 
            if(availableChickens > 5)
            {
                int priceDropRange = 5;
                int priceDropForSwitchCase = priceDrop / priceDropRange;

                switch (priceDropForSwitchCase)
                {
                    case 0: 
                    case 1: return 1 + random.Next((availableChickens / 5), (availableChickens / 4)); 
                    case 2: return 1 + random.Next((availableChickens / 4), (availableChickens / 3));
                    case 3: return 1 + random.Next((availableChickens / 3), (availableChickens / 2));
                    default: return 1 + random.Next((availableChickens / 3), (availableChickens / 2));
                }
            }

            /*
             * else purchase all the available chickens 
             */ 
            else
            {
                return availableChickens;
            }
            
        }

        /*
         * A function to handle the price cut event
         */ 
        public void chickenOnSale(Int32 oldPrice, int price, Int32 availableChickens, Int32 priceDrop)
        {
            Console.WriteLine("________________________________________________________________________________");
            Console.WriteLine("\tOld Price: ${0} New Price : ${1} Price Dropped by : ${2} \n\tNew Order requested by Thread{3}", oldPrice, price, priceDrop,threadID);

            ReaderWriterLock rwl = new ReaderWriterLock();
            Encoder encoder = new Encoder();

            TimeStamp timestamp = new TimeStamp();
            
            MultiCellBuffer buffer = new MultiCellBuffer(threadID);     
            try
            {
                acquireLock(rwl);

                Order order = setOrderObject(threadID,price,availableChickens,priceDrop);
                /*
                 * Encoding the order object and writing the data in the buffer cell
                 */ 
                String encryptedOrder = encoder.encryptOrder(threadID, order);
                buffer.setOneCell(threadID, encryptedOrder);

                /* 
                 * A class to process the order and send back the status of the order
                 */ 
                OrderProcessing orderProcessClass = new OrderProcessing();
                orderProcessClass.processOrder(timestamp,buffer, threadID);

                /*
                 * Time stamp to calculate the time taken to process the order
                 */ 
                timestamp.End = DateTime.Now;

                Console.Write("   Time Elapsed : ");
                Console.Write("{1} ms", threadID, timestamp.timeStampDifference());
            }
            finally
            {
                releaseLock(rwl);
                Console.WriteLine("\n________________________________________________________________________________");
            }
        }      
    }
}

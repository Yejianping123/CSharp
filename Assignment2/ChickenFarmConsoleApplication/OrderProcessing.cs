using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChickenFarmConsoleApplication
{
    /*
     * A class to process the order received
     */
    class OrderProcessing
    {
        ReaderWriterLock rwl = new ReaderWriterLock();

        /*
         * Event handler and delegates to handle the order confirmation event
         */
        public delegate void orderConfirmationEvent(Int32 threadId, Int32 maxLimit);
        public static event orderConfirmationEvent orderConfirmation;

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
         * check the feasibility of placing the order based on the amount 
         * of chicken requested 
         */
        public Boolean checkFeasibilityWithQuantity(Int32 orderCount)
        {
            return (ChickenFarm.totalChickenCount - ChickenFarm.chickensPurchased - orderCount >= 0);
        }

        /*
         * A function to calculate the total cost of the order
         * totalCost = costPrice + Tax + Shipment
         * costPrice = unitPrice * quantity
         * Tax = 8% of CP
         * Shipment = 10% of CP
         */
        public double calculateSellingPrice(Order order)
        {
            Int32 unitPrice = Convert.ToInt32(order.SellingPrice);
            Int32 quantity = Convert.ToInt32(order.Amount);
            double costPrice = unitPrice * quantity;
            double salesTax = 0.08 * costPrice;
            double shippingCharges = 0.10 * costPrice;
            return Convert.ToDouble(costPrice + salesTax + shippingCharges);
        }

        /*
         * A function to display the order in a format.
         */
        public void display(Order order)
        {
            Console.WriteLine("  ____________________________________________________________________________");
            Console.WriteLine("   Order Details                                                              ");
            Console.WriteLine("  ____________________________________________________________________________");
            Console.WriteLine("\tOrderNo: {0}\tSenderID: {1}\t\tCardNo: {2}\n\tAmount: {3}\tSellingPrice: {4}\tTotalAmount: {5}",
                order.OrderNo, order.SenderID, order.CardNo, order.Amount, order.SellingPrice, order.TotalAmount);
            Console.WriteLine("  ____________________________________________________________________________");
        }

        /*
         * A function to update the totalOrders made
         */
        public void updateTotalOrder(Int32 amount)
        {
            ChickenFarm.chickensPurchased += Convert.ToInt32(amount);
        }

        /*
         * A function to check the current chicken availability
         */
        public int currentChickenAvailability()
        {
            return ChickenFarm.totalChickenCount - ChickenFarm.chickensPurchased;
        }

        public Boolean isValidCard(int cardNo)
        {
            return (cardNo >= 5000 && cardNo <= 7000);
        }
        /*
         * A function to process the order
         */
        public Boolean processOrder(TimeStamp ts, MultiCellBuffer buffer, Int32 threadId)
        {
            Encoder decoder = new Encoder();

            acquireLock();
            /*
             * Decrypting the order read from the buffer and calculating 
             * the totalCost using the calculateSellingPrice method.
             */
            Order order = decoder.decryptOrder(buffer, threadId);
            order.TotalAmount = calculateSellingPrice(order);
            display(order);

            Console.Write("   Order Status : ");

            try
            {
                if (isValidCard(order.CardNo))
                {
                    /*
                     * Check if the order can be placed
                     */
                    if (checkFeasibilityWithQuantity(order.Amount))
                    {
                        Retailer retailer = new Retailer();
                        updateTotalOrder(order.Amount);

                        /*
                         * Subscribing to order confirmation event 
                         */
                        orderConfirmation += new orderConfirmationEvent(retailer.orderConfirmationCallBack);
                        /*
                         * Status information about the order and chicken availability is sent to the handler.
                         */
                        orderConfirmation(threadId, currentChickenAvailability());
                        /*
                         * Unsubscribing to order confirmation event 
                         */
                        orderConfirmation -= new orderConfirmationEvent(retailer.orderConfirmationCallBack);

                        return true;
                    }

                    else
                    {
                        /*
                         * If it cannot be placed notify the possible reason 
                         * due to the sold out chicken or requesting more chicken than
                         * the available chickens.
                         */
                        if (ChickenFarm.chickensPurchased == 100)
                            Console.WriteLine("Order cannot be processed, all {0} chickens have been sold out.", ChickenFarm.totalChickenCount);
                        else
                            Console.WriteLine("Order cannot be processed, chicken amount needs to be <= {0}", currentChickenAvailability());

                        return false;
                    }
                }

                else
                {
                    Console.WriteLine("Order is not in the range");
                    return false;
                }

            }

            finally
            {
                releaseLock();
                Console.WriteLine("  ____________________________________________________________________________");
            }
        }
    }
}

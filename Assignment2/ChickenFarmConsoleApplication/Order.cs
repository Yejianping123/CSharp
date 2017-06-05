using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenFarmConsoleApplication
{
    class Order
    {
        /*
         * Order attributes 
         */
        private Int32 orderNo;
        private Int32 senderID;
        private Int32 cardNo;
        private Int32 amount;
        private Int32 sellingPrice;
        private double totalAmount;

        /*
         * OrderNo attribute encapsulation
         */ 
        public int OrderNo
        {
            get
            {
                return orderNo;
            }

            set
            {
                orderNo = value;
            }
        }

        /*
         * senderID attribute encapsulation
         */
        public int SenderID
        {
            get
            {
                return senderID;
            }

            set
            {
                senderID = value;
            }
        }

        /*
         * OrderNo attribute encapsulation
         */
        public int CardNo
        {
            get
            {
                return cardNo;
            }

            set
            {
                cardNo = value;
            }
        }

        /*
         * Amount attribute encapsulation
         */
        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        /*
         * SellingPrice attribute encapsulation
         */
        public int SellingPrice
        {
            get
            {
                return sellingPrice;
            }

            set
            {
                sellingPrice = value;
            }
        }

        /*
         * TotalAmount attribute encapsulation
         */
        public double TotalAmount
        {
            get
            {
                return totalAmount;
            }

            set
            {
                totalAmount = value;
            }
        }

        /*
         * Printing order
         */ 
        public void toString()
        {
            Console.WriteLine("  ____________________________________________________________________________");
            Console.WriteLine("   Order Details                                                              ");
            Console.WriteLine("  ____________________________________________________________________________");
            Console.WriteLine("\tOrderNo: {0}\tSenderID: {1}\t\tCardNo: {2}\n\tAmount: {3}\tSellingPrice: {4}\tTotalAmount: {5}",
                this.OrderNo, this.SenderID, this.CardNo, this.Amount, this.SellingPrice, this.TotalAmount);
            Console.WriteLine("  ____________________________________________________________________________");
        }
    }
}

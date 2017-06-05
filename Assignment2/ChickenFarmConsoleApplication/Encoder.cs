using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenFarmConsoleApplication
{
    /*
     * Class to encode the order received into string and encrypt
     * it using the encryption web service hosted in 
     * http://neptune.fulton.ad.asu.edu/WSRepository/Services/EncryptionWcf/Service.svc
     */
    class Encoder
    {
        /*
         * Method to encode order object into string and encrypt the string using
         * the mentioned encryption service.   
         */
        public String encryptOrder(Int32 threadId, Order order)
        {
            String encryptedString;
            /*
             * Encryption service hosted in 
             * http://neptune.fulton.ad.asu.edu/WSRepository/Services/EncryptionWcf/Service.svc
             */
            CryptoService.ServiceClient serviceClient = new CryptoService.ServiceClient();

            String orderNo = Convert.ToString(order.OrderNo);
            String senderID = Convert.ToString(order.SenderID);
            String cardNo = Convert.ToString(order.CardNo);
            String amount = Convert.ToString(order.Amount);
            String sellingPrice = Convert.ToString(order.SellingPrice);

            /*
             * Enclose every field of the order object within | to convert object into string
             */ 
            encryptedString = serviceClient.Encrypt(orderNo + '|' + senderID + '|' + cardNo + '|' + amount + '|' + sellingPrice);

            Console.WriteLine("\tEncoded Order : {0}",encryptedString);
            return encryptedString;
        }

        /*
         * Method to decrypt the string using the mentioned encryption service and 
         * decode encrypted string into order object. 
         */
        public Order decryptOrder(MultiCellBuffer buffer,int threadID)
        {
            String decryptedOrderString;
            String[] orderValues;
            Order order = new Order();

            /*
             * Decryption service hosted in 
             * http://neptune.fulton.ad.asu.edu/WSRepository/Services/EncryptionWcf/Service.svc
             */
            CryptoService.ServiceClient serviceClient = new CryptoService.ServiceClient();     
            decryptedOrderString = serviceClient.Decrypt(buffer.getOneCell(threadID));

            /*
             * Disclose every field of the order string using | to get back the order object
             */
            orderValues = decryptedOrderString.Split('|');                                  

            /*
             * Values to be assigned based on the order it was encoded.
             * Get the associated value from the respective index and 
             * assign it to the associated attribute of the order object
             */ 
            order.OrderNo = Convert.ToInt32(orderValues[0]);
            order.SenderID = Convert.ToInt32(orderValues[1]);
            order.CardNo = Convert.ToInt32(orderValues[2]);
            order.Amount = Convert.ToInt32(orderValues[3]);
            order.SellingPrice = Convert.ToInt32(orderValues[4]);
            return order;
        }
    }
}

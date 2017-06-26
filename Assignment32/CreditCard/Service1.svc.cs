using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Web;

namespace CreditCard
{
    /*
         * A service implemetation for credit card validation using RESTFUL services 
         */
    public class Service1 : IService1
    {
        /*
         * check if the credit card file is available or not otherwise throw error
         */ 
        bool checkForFile(string filePath, string cardNo, string date, string name, string cvv)
        {
            List<string> list = new List<string>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add(sr.ReadLine().ToLower());
                    }
                }
            }
            else { return false; }

            /*
             * see if all the provided values are available in the local text file
             * If yes return true
             */ 
            foreach (string card in list)
            {
                string[] element = card.Split(' ');
                return (element[0] == cardNo.ToLower() && element[1] == date.ToLower()
                    && element[2] == name.ToLower() && element[3] == cvv.ToLower());
            }

            return false;
        }

        public string ValidateCreditCardInfo(string cardNo, string date, string name, string cvv)
        {
            /*
             * Retrieve the path of the credit card text file and send it for validation
             */ 
            string fileName = "Cards.txt";
            string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, fileName);

            if (cardNo == null || date == null || name == null || cvv == null) { return "Status : Validation Failed"; }
            return checkForFile(filePath, cardNo, date, name, cvv) 
                ? "Status : Validation Success" : "Status : Validation Failed";
        }
    }
}

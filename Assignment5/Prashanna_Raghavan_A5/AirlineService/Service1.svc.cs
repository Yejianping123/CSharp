using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

namespace AirlineService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        /*
             * enum to maintain the status of the ticket request
             */
        enum BookingStatus
        {
            Reserve = 1,
            Cancel = 2
        }

        /*
         * function to return a random number
         */
        private string generateRandomID()
        {
            return Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
        }

        /*
         * Text files to maintain the records
         */
        string getTickets() { return "Availability.txt"; }
        string getReservedTickets() { return "Tickets.txt"; }

        /*
         * a condition to check the correctness of the entered values
         */
        bool checkCondition(string ticket, string date, string from, string to, int noOfTickets)
        {
            string[] elements = ticket.Split(' ');
            return (elements[0] == date && elements[1] == from && elements[2] == to && Convert.ToInt32(elements[5]) >= noOfTickets);
        }

        /*
         * a function to check the availability of tickets
         */
        public bool isTicketAvailable(string date, string from, string to, int noOfTickets, string start = null, string end = null)
        {
            /*
             * Check the path of the file
             */
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, getTickets());
            List<string> currentList;

            if (date == null || from == null || to == null || !File.Exists(path)) { return false; }
            /*
             * retrieve the records as list
             */
            else { currentList = returnList(getTickets()); }

            /*
             * iterate through the list and find the matching flights
             * If available return yes
             */
            foreach (string ticket in currentList)
            {
                if (checkCondition(ticket, date, from, to, noOfTickets))
                {
                    if (start == null || end == null) { return true; }
                    else
                    {
                        string[] elements = ticket.Split(' ');
                        if (elements[3] == start && elements[4] == end) { return true; }
                        else { continue; }
                    }
                }
            }

            return false;
        }

        /*
             * retrieve the records as list for a given text file
             */
        List<string> returnList(string fileName)
        {
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, fileName);
            List<string> list = new List<string>();
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {               
                        if(sr.ReadLine() != String.Empty || sr.ReadLine() != null)
                        {
                            list.Add(sr.ReadLine());
                        }                      
                    }
                }
            }

            return list;
        }

        /*
         * A service implementation to find the matching flights on a given date
         * source destination and nooftickets 
         */
        public string[] MatchingFlights(string date, string from, string to, int noOfTickets)
        {
            List<string> currentList = returnList(getTickets());
            List<string> matchingList = new List<string>();
            /*
             * iterate through the list and add matching flights in a list and return it
             */
            foreach (string ticket in currentList)
            {
                if (checkCondition(ticket, date, from, to, noOfTickets))
                {
                    string[] elements = ticket.Split(' ');
                    String flights = elements[0] + ' ' + elements[1] + ' ' + elements[2] + ' ' + elements[3] + ' ' + elements[4];
                    matchingList.Add(flights);
                }
            }

            return matchingList.ToArray();
        }

        /*
         * A service implementation to find the all flights from the xml 
         */
        public string[] CompleteFlights()
        {
            List<string> currentList = returnList(getTickets());
            List<string> matchingList = new List<string>();
            /*
             * iterate through the list and add all flights in a list and return it
             */
            foreach (string ticket in currentList)
            {
                string[] elements = ticket.Split(' ');
                String flights = elements[0] + ' ' + elements[1] + ' ' + elements[2] + ' ' + elements[3] + ' ' + elements[4];
                matchingList.Add(flights);
            }

            return matchingList.ToArray();
        }

        /*
         * An update function to update the contents of the text file 
         * when the ticket is booked 
         */
        private void updateDB(string date, string from, string to, string start, string end, int noOfTickets, BookingStatus transactionType)
        {
            int counter = 0;
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, getTickets());
            List<string> currentList;

            /*
             * If the file exists in the path
             * retrieve the row entry and update the count 
             * and put it back into the text file
             */
            if (File.Exists(path))
            {
                currentList = returnList(getTickets());
                List<string> changedEntry = currentList;
                /*
                 * iterate over the list
                 */
                foreach (string ticket in currentList)
                {
                    /*
                     * decouple and check for correctness
                     */
                    string[] elements = ticket.Split(' ');
                    if (checkCondition(ticket, date, from, to, noOfTickets) && elements[3] == start && elements[4] == end)
                    {
                        /*
                         * update the new ticket availability by 
                         * deducting the tickets purchased
                         */
                        int newAvailability = 0;
                        if (transactionType == BookingStatus.Reserve) { newAvailability = Convert.ToInt32(elements[5]) - noOfTickets; }
                        else if (transactionType == BookingStatus.Cancel) { newAvailability = Convert.ToInt32(elements[5]) + noOfTickets; }
                        string newEntry = elements[0] + ' ' + elements[1] + ' ' + elements[2] + ' ' + elements[3] + ' ' + elements[4] + ' ' + newAvailability;
                        /*
                         * update the list entry
                         */
                        changedEntry[counter] = newEntry;
                        break;
                    }
                    counter++;
                }

                /*
                 * put the contents back into the text file
                 */
                File.WriteAllLines(path, changedEntry.ToArray());
            }
        }

        /*
         * A function to write the tickets back into the text file
         */
        bool writeTickets(string userID, string date, string from, string to, string start, string end, int noOfTickets)
        {
            /*
             * get the path, open the file and update the contents
             */
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, getReservedTickets());
            string bookedTicketsInfo = generateRandomID() + ' ' + userID + ' ' + date + ' ' + from + ' ' + to + ' ' + start + ' ' + end + ' ' + noOfTickets;

            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    /*
                     * write the entry and update the contents accordingly
                     */
                    sw.WriteLine(bookedTicketsInfo);
                    updateDB(date, from, to, start, end, noOfTickets, BookingStatus.Reserve);
                    return true;
                }
            }

            return false;
        }

        /*
         * A function to reserve the ticket
         * check for availability and purchase if the ticket purchased is less than or equal to available tickets
         */
        public bool ReserveTickets(string userID, string date, string from, string to, string start, string end, int noOfTickets)
        {
            bool isTicketsAvailable = isTicketAvailable(date, from, to, noOfTickets, start, end);
            if (isTicketsAvailable) { return writeTickets(userID, date, from, to, start, end, noOfTickets); }
            return false;
        }

        /*
         * A service to cancel the booked ticket using confirmation number
         */ 
        public bool CancelTicket(string confirmationNo)
        {
            int count = 0, index = 0;
            bool match = false;

            /*
             * Get the path of the text file
             */ 
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, getReservedTickets());

            /*
             * If file exist get to the matching record and update the contents
             */ 
            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        String str = streamReader.ReadLine();
                        string[] elements = str.Split(' ');
                        if (elements[0].ToLower() == confirmationNo.ToLower())
                        {
                            index = count++;
                            match = true;
                            updateDB(elements[2], elements[3], elements[4], elements[5], elements[6], Convert.ToInt32(elements[7]), BookingStatus.Cancel);
                            break;
                        }
                        count++;
                    }
                }
            }

            /*
             * If match found remove the record and update the text file accordingly
             */ 
            if (File.Exists(path) && match == true)
            {
                List<string> list = File.ReadAllLines(path).ToList();
                list.RemoveAt(index);
                File.WriteAllLines(path, list.ToArray());
                return true;
            }
            else { return false; }
            return false;
        }
    }
}

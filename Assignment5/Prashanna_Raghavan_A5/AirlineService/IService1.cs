using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AirlineService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /*
         * A service interface to cancel ticket
         */

        [OperationContract]
        bool CancelTicket(string confirmationNo);

        /*
         * A service interface to find all available flights
         */

        [OperationContract]
        string[] CompleteFlights();

        /*
         * A service interface to check the ticket availability
         */
        [OperationContract]
        bool isTicketAvailable(string date, string from, string to, int noofTickets, string start = null, string end = null);

        /*
         * A service interface to check the reserve the ticket 
         */
        [OperationContract]
        bool ReserveTickets(string userID, string date, string from, string to, string start, string end, int noofTickets);

        /*
        * A service interface to check the find available tickets
        */

        [OperationContract]
        string[] MatchingFlights(string date, string from, string to, int noofTickets);
    }
}

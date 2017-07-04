using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    /*
    [OperationContract]
    string[] CancelFlights();
    */
    /*
     * A service interface to check the find available tickets
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CreditCard
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /*
         * A service interface for credit card validation using RESTFUL services 
         */
        [OperationContract]
        [WebGet(UriTemplate = "validate?cardNo={cardNo}&expiry={date}&name={name}&cvv={cvv}")]
        string ValidateCreditCardInfo(string cardNo, string date, string name, string cvv);
    }
}

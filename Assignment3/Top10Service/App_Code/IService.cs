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
     * An interface for Top10 Words service
     */ 
    [OperationContract]
    string[] Top10Words(string URL);

    // TODO: Add your service operations here
}
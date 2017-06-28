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
     * Service interface for validating XML and adding new person
     */ 
    [OperationContract]
    string XMLValidation(string XMLPath, string XSDPath);

    [OperationContract]
    string AddNewPerson(string add);
}
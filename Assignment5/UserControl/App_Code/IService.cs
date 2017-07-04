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
     * A service interface to Encrypt a string
     */ 
    [OperationContract]
    string Encrypt(string plainText);

    /*
     * A service interface to Decrypt a string
     */
    [OperationContract]
    string Decrypt(string cipherText);

    /*
     * A service interface to Register a user
     */

    [OperationContract]
    string RegisterUser(string username, string password, string confirmPassword);

    /*
     * A service interface to Authenticate a user

     */
    [OperationContract]
    string AuthenticateUser(string username, string password); 
}

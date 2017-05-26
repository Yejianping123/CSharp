using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TemperatureConversion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /* 
           Service Interface to convert temperature represented in celicus to fahrenheit 
        */
        [OperationContract]
        int c2f(int c);

        /* 
           Service Interface to convert temperature represented in fahrenheit to celicus
        */
        [OperationContract]
        int f2c(int f);
    }
}

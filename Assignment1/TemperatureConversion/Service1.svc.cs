using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TemperatureConversion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        /* 
           Service Implementation to convert temperature represented in celicus to fahrenheit 
        */

        public int c2f(int c)
        {
            return Convert.ToInt32(c * (1.8) + 32);
        }

        /* 
           Service Interface to convert temperature represented in fahrenheit to celicus
        */

        public int f2c(int f)
        {
            return Convert.ToInt32((f-32)/1.8);
        }
    }
}

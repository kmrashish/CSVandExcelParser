using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_demo_one
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int AddTwoNumbers(int a, int b);


        [OperationContract]
        string SayHello(string name);

        // TODO: Add your service operations here
    }
}
   
   

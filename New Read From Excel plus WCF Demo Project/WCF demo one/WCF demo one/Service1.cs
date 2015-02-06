using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_demo_one
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public int AddTwoNumbers(int a, int b)
        {
            return a+b;
        }

        public string SayHello(string name)
        {
            return "Hello "+name;
        }
    }
}

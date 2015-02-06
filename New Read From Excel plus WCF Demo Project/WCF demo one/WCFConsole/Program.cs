using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCF_demo_one;


namespace WCFConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(IService1), new Uri[] { new Uri(@"http://localhost:8747/IService1") }))
            {
                host.Open();

                Console.Write("Please press enter to terminate WCF host...  ");
                Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_1_Lab.Model;

namespace OOP_1_Lab.ViewModel
{
    class ViewModel
    {
        
        public void Method()
        {
            Auto a = new Auto();
            a.Route = new TransportRoute(new LinkedList<Stop>(), "d", 1);
            //string[] arr =  (string[])Enum.GetValues(typeof(Auto.Types));
        }
    }
}

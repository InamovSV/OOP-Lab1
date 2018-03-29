using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_1_Lab.Model;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TransportRoute tr = new TransportRoute();
            tr.Stops.Add(new Stop("das", "sd", "ds"));
            tr.Stops.Add(new Stop("d", "s", "fsd"));
            TransportRoute tr1 = new TransportRoute();
            tr1.Stops.Add(new Stop("das", "sd", "ds"));
            tr1.Stops.Add(new Stop("d", "s", "fsd"));

            Console.WriteLine(tr.Equals(tr1));

            Console.ReadKey();
        }
    }
}

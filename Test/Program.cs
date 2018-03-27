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
            Driver dr = new Driver("1", "1", "1", "1");
            dr.AddTransport(new Auto("1", 1, 1, Auto.Types.Car));
            dr.AddTransport(new Train("2", 2, 2, Train.Types.FreightTrain));
            Driver dr1 = new Driver("2", "2", "2", "2");
            dr1.AddTransport(new Auto("1", 1, 1, Auto.Types.Car));

            Console.ReadKey();
        }
    }
}

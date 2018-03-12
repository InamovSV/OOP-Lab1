using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_1_Lab.Model
{
    abstract class Transport : Base<Transport>
    {
        public Transport()
        {

        }
        string _model;
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (value != null && value.Length < 20)
                    _model = value;
            }
        }

        public TransportRoute Route { get; set; }

        public Driver Driver { get; set; }

        abstract public int CarryingCapacity { get; set; }

        abstract public int PeopleCapacity { get; set; }

        
        //public static List<Transport> GetTransportsWithOneType(Transport.Types type)
        //{
        //    List<Transport> res = new List<Transport>();
        //    foreach (var item in Transport.Items.Values)
        //    {
        //        if (item.Type == type)
        //            res.Add(item);
        //    }
        //    return res;
        //}

    }
}

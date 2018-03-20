using System;
using System.Collections.Generic;


namespace OOP_1_Lab.Model
{
    abstract class Transport : Base<Transport>
    {
        public Transport(string model, int carryingCapacity, int peopleCapacity, Driver driver = null, TransportRoute route = null)
        {
            Model = model;
            CarryingCapacity = carryingCapacity;
            PeopleCapacity = peopleCapacity;
            _driver = new List<Driver>();
            Drivers.Add(driver);
        }

        string _model;
        List<Driver> _driver;

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
        
        public List<Driver> Drivers
        {
            get
            { return _driver; }
        }

        public TransportRoute Route { get; set; }

        abstract public int CarryingCapacity { get; set; }

        abstract public int PeopleCapacity { get; set; }

        public bool IsOnWay { get; set; }

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
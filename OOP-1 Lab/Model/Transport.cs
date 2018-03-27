using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OOP_1_Lab.Model
{
    public abstract class Transport //: Base<Transport>
    {
        public Transport(string model, int carryingCapacity, int peopleCapacity)
        {
            Model = model;
            CarryingCapacity = carryingCapacity;
            PeopleCapacity = peopleCapacity;
            _drivers = new ObservableCollection<Driver>();
            //LogisticSystem.Transports.Add(this);
        }

        string _model;
        ObservableCollection<Driver> _drivers;

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
        
        public ObservableCollection<Driver> Drivers
        {
            get
            {
                return _drivers;
            }
        }

        //public TransportRoute Route { get; set; }

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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace OOP_1_Lab.Model
{
    [DataContract]
    public abstract class Transport : Base<Transport>
    {
        string _model;

        public Transport(string model, int carryingCapacity, int peopleCapacity)
        {
            Model = model;
            CarryingCapacity = carryingCapacity;
            PeopleCapacity = peopleCapacity;
        }

        [DataMember]
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
                ObservableCollection<Driver> listDr = new ObservableCollection<Driver>();
                foreach (var item in DriverTransportContext.Items.Values)
                    if (item.Transport == this)
                        listDr.Add(item.Driver);
                return listDr;
            }
        }

        //public TransportRoute Route { get; set; }
        [DataMember]
        abstract public int CarryingCapacity { get; set; }
        [DataMember]
        abstract public int PeopleCapacity { get; set; }
        [DataMember]
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
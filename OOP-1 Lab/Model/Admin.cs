using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    class Admin
    {
        public Admin()
        {
            _transports = new List<Transport>();
           _drivers = new List<Driver>();
        }

        private List<Transport> _transports;
        private List<Driver> _drivers;

        public List<Transport> Transports
        {
            get
            {
                return _transports;
            }
        }

        public List<Driver> Drivers
        {
            get
            {
                return _drivers;
            }
        }
        //TO DO возврат клонированной коллекции

        public void Add(Driver dr)
        {
            Drivers.Add(dr);
            foreach (var item in dr.Transports)
            {
                if (!Transports.Contains(item))
                {
                    Transports.Add(item);
                }
            }
        }

        public void Add(Transport tr)
        {
            Transports.Add(tr);
            foreach (var item in tr.Drivers)
            {
                if (!Drivers.Contains(item))
                {
                    Drivers.Add(item);
                }
            }
        }

        public void Remove(Driver dr)
        {
            foreach (var item in dr.Transports)
            {
                item.Drivers.Remove(dr);
            }
            Drivers.RemoveAll(item => item == dr);
        }

        public void Remove(Transport tr)
        {
            foreach (var item in tr.Drivers)
            {
                item.Transports.Remove(tr);
            }
            Transports.RemoveAll(item => item == tr);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    public class Customer : User
    {
        public Customer(string name, string login, string password)
        {
            Transports = new ObservableCollection<Transport>();
           _drivers = new ObservableCollection<Driver>();
            Login = login;
            Password = password;
            Name = name;
        }

        private ObservableCollection<Transport> _transports;
        private ObservableCollection<Driver> _drivers;
        private string _login;
        private string _password;
        private string _name;

        public ObservableCollection<Transport> Transports
        {
            get
            {
                return _transports;
            }
            private set
            {
                _transports = value;
            }
        }

        public ObservableCollection<Driver> Drivers
        {
            get
            {
                return _drivers;
            }
            private set
            {
                _drivers = value;
            }
        }

        public override string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        public override string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if(value.Length < 25)
                _name = value;
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
            Drivers.Remove(dr);
        }

        public void Remove(Transport tr)
        {
            foreach (var item in tr.Drivers)
            {
                item.Transports.Remove(tr);
            }
            Transports.Remove(tr);
        }

        public override bool Equals(object obj)
        {
            if (obj is User)
                return Login == obj.ToString();
            else throw new ArgumentException();
        }

        public override int GetHashCode()
        {
            return Login.GetHashCode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    // Статический класс для взаимодействия с коллекциями (сериализация будет проводится по классу customer и driver)
    class LogisticSystem
    {
        static LogisticSystem()
        {
            Transports = new ObservableCollection<Transport>();
            TransportRouts = new ObservableCollection<TransportRoute>();
            Drivers = new ObservableCollection<Driver>();
            Customers = new ObservableCollection<Customer>();
        }
        static ObservableCollection<Customer> _customer;
        static ObservableCollection<Driver> _drivers;
        static ObservableCollection<Transport> _transports;
        static ObservableCollection<TransportRoute> _transportRouts;

        public static ObservableCollection<Customer> Customers
        {
            get
            {
                return _customer;
            }

            set
            {
                _customer = value;
            }
        }

        public static ObservableCollection<Driver> Drivers
        {
            get
            {
                return _drivers;
            }

            set
            {
                _drivers = value;
            }
        }

        public static ObservableCollection<Transport> Transports
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

        public static ObservableCollection<TransportRoute> TransportRouts
        {
            get
            {
                return _transportRouts;
            }

            private set
            {
                _transportRouts = value;
            }
        }

        #region Methods

        #region Serialization
        public static void SaveAll()
        {

        }

        public static void LoadAll()
        {

        }
        #endregion

        #region Autorization
        public static void AddCustomer(string name, string login, string password)
        {
            if (new Regex(@"@c$").IsMatch(password))
            {
                bool isContains = false;
                foreach (var item in Customers)
                {
                    isContains = item.Login == login ? true : false;
                    if (isContains)
                        break;
                }
                if (!isContains)
                    Customers.Add(new Customer(name, login, password));
                else throw new Exception("User with such login already exist");
            }
            else
                throw new ArgumentException("Invalid term in the expression");
        }

        public static void AddDriver(string firstName, string lastName, string login, string password)
        {
            if (!(new Regex(@"@c$").IsMatch(password)))
            {
                bool isContains = false;
                foreach (var item in Drivers)
                {
                    isContains = item.Login == login ? true : false;
                    if (isContains)
                        break;
                }
                if (!isContains)
                {
                    Drivers.Add(new Driver(firstName, lastName, login, password));
                }
                else throw new Exception("User with such login already exist");
            }
            else
                throw new ArgumentException("Invalid term in the expression");
        }

        public static Driver GetDriver(string login, string password)
        {
            //if (!(new Regex(@"@c$").IsMatch(password)))
            //{
                foreach (var item in Drivers)
                {
                    if (item.Login == login && item.Password == password)
                        return item;
                }
                throw new ArgumentException("Incorrect username or password");
            //}
            //else
            //    throw new ArgumentException("Invalid term in the expression");
        }

        public static Customer GetCustomer(string login, string password)
        {
            //if (new Regex(@"@c$").IsMatch(password))
            //{
                foreach (var item in Customers)
                {
                    if (item.Login == login && item.Password == password)
                        return item;
                }
                throw new ArgumentException("Incorrect username or password");
            //}
            //else
            //    throw new ArgumentException("Invalid term in the expression");
        }
        #endregion

        #region Mutate collection
        //public void Add(Driver dr)
        //{
        //    Drivers.Add(dr);
        //    foreach (var item in dr.GetTransports())
        //    {
        //        if (!Transports.Contains(item))
        //        {
        //            Transports.Add(item);
        //        }
        //    }
        //}

        //public void Add(Transport tr)
        //{
        //    Transports.Add(tr);
        //    foreach (var item in tr.Drivers)
        //    {
        //        if (!Drivers.Contains(item))
        //        {
        //            Drivers.Add(item);
        //        }
        //    }
        //}

        //public void Remove(Driver dr)
        //{
        //    foreach (var item in dr.GetTransports())
        //    {
        //        item.Drivers.Remove(dr);
        //    }
        //    Drivers.Remove(dr);
        //}

        //public void Remove(Transport tr)
        //{
        //    foreach (var item in tr.Drivers)
        //    {
        //        item.GetTransports().Remove(tr);
        //    }
        //    Transports.Remove(tr);
        //}
        #endregion
        #endregion

    }
}

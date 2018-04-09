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

        }
        public static ObservableCollection<Customer> Customers
        {
            get
            {
                ObservableCollection<Customer> listRes = new ObservableCollection<Customer>();
                foreach (var item in Customer.Items.Values)
                    if(item is Customer)
                        listRes.Add(item);
                return listRes;
            }
        }

        public static ObservableCollection<Driver> Drivers
        {
            get
            {
                ObservableCollection<Driver> listRes = new ObservableCollection<Driver>();
                foreach (var item in Driver.Items.Values)
                    if(item is Driver)
                        listRes.Add(item);
                return listRes;
            }
        }

        public static ObservableCollection<Transport> Transports
        {
            get
            {
                ObservableCollection<Transport> listRes = new ObservableCollection<Transport>();
                foreach (var item in Transport.Items.Values)
                    listRes.Add(item);
                return listRes;
            }
        }

        public static ObservableCollection<TransportRoute> TransportRouts
        {
            get
            {
                ObservableCollection<TransportRoute> listRes = new ObservableCollection<TransportRoute>();
                foreach (var item in TransportRoute.Items.Values)
                    listRes.Add(item);
                return listRes;
            }
        }

        #region Methods

        #region Serialization
        public static void SaveAll()
        {
            Customer.Save();
            Driver.Save();
            DriverTransportContext.Save();
            TransportRoute.Save();
            Auto.Save();
            Plane.Save();
            Ship.Save();
            Train.Save();
            Stop.Save();
        }

        public static void LoadAll()
        {
            Customer.Load();
            Driver.Load();
            DriverTransportContext.Load();
            TransportRoute.Load();
            Auto.Load();
            Plane.Load();
            Ship.Load();
            Train.Load();
            Stop.Load();
        }
        #endregion

        #region Autorization
        public static void AddCustomer(string name, string login, string password)
        {
            if (new Regex(@"@c$").IsMatch(login))
            {
                bool isContains = false;
                foreach (var item in Customers)
                {
                    isContains = item.Login == login ? true : false;
                    if (isContains)
                        break;
                }
                if (!isContains)
                    new Customer(name, login, password);
                else throw new Exception("IUser with such login already exist");
            }
            else
                throw new ArgumentException("Invalid term in the expression");
        }

        public static void AddDriver(string firstName, string lastName, string login, string password)
        {
            if (!(new Regex(@"@c$").IsMatch(login)))
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
                    new Driver(firstName, lastName, login, password);
                }
                else throw new Exception("IUser with such login already exist");
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

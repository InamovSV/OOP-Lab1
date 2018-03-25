using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    // Статический класс для взаимодействия с коллекциями (сериализация будет проводится по классу admin, driver и account)
    class LogisticSystem
    {
        static ObservableCollection<Customer> _customer;
        static ObservableCollection<Driver> _drivers;
        static ObservableCollection<Transport> _transports;
        static ObservableCollection<TransportRoute> _transportRouts;
        //взаимодействует с классом Login

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

            set
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

            set
            {
                _transportRouts = value;
            }
        }

        #region Methods
        public static void SaveAll()
        {

        }

        public static void LoadAll()
        {

        }

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
                    Drivers.Add(new Driver(firstName, lastName, login, password));
                else throw new Exception("User with such login already exist");
            }
            else
                throw new ArgumentException("Invalid term in the expression");
        }
        #endregion

    }
}

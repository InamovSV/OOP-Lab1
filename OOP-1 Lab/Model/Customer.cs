using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    public class Customer : User
    {
        public Customer(string name, string login, string password)
        {
            Login = login;
            Password = password;
            Name = name;
            Routs = new ObservableCollection<TransportRoute>();
        }

        //private ObservableCollection<Transport> _transports;
        //private ObservableCollection<Driver> _drivers;
        private string _login;
        private string _password;
        private string _name;
        private ObservableCollection<TransportRoute> _routs;

        public ObservableCollection<Transport> Transports
        {
            get
            {
                return LogisticSystem.Transports;
            }
        }

        public ObservableCollection<Driver> Drivers
        {
            get
            {
                return LogisticSystem.Drivers;
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
                if (new Regex(@"@c$").IsMatch(value) && value.Length < 25)
                    _login = value;
                else
                    throw new ArgumentException("Invalid term in the expression");
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
                if (value.Length < 25)
                    _name = value;
            }
        }

        public ObservableCollection<TransportRoute> Routs
        {
            get
            {
                return _routs;
            }

            private set
            {
                _routs = value;
            }
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

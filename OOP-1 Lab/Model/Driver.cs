using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace OOP_1_Lab.Model
{
    public class Driver : User
    {
        string _firstName;
        string _lastName;
        int _experience;
        int _earnings;
        string _phoneNumber;
        string _login;
        string _password;
        TransportRoute _currentRoute;
        ObservableCollection<Transport> _transports;
        ObservableCollection<TransportRoute> _historyOfRouts;

        public Driver(string firstName, string lastName, string login, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Experience = 0;
            _transports = new ObservableCollection<Transport>();
        }

        #region Properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != "" && value != null)
                    _firstName = value;
                else throw new ArgumentException();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != "" && value != null)
                    _lastName = value;
                else throw new ArgumentException();
            }
        }

        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value >= 0 && value < 100)
                    _experience = value;
                else throw new ArgumentException();
            }
        }

        public int Earnings
        {
            get
            {
                return _earnings;
            }
            set
            {
                _earnings = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                _phoneNumber = value;
            }
        }

        public ObservableCollection<TransportRoute> HistoryOfRouts
        {
            get
            {
                return _historyOfRouts;
            }

            set
            {
                _historyOfRouts = value;
                ++Experience;
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
                if (!(new Regex(@"@c$").IsMatch(value)))
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

        public TransportRoute CurrentRoute
        {
            get
            {
                return _currentRoute;
            }

            set
            {
                _currentRoute = value;
            }
        }

        #endregion

        public void AddTransport(Transport tr)
        {
            Transport tempTr;
            try
            {
                tempTr = LogisticSystem.Transports.First((t) => t.Equals(tr));
            }
            catch (InvalidOperationException)
            {
                tempTr = null;
            }
            if (tempTr != null)
            {
                if (!tempTr.Drivers.Contains(this))
                    tempTr.Drivers.Add(this);
                if (!_transports.Contains(tr))
                    _transports.Add(tempTr);
            }
            else
            {
                if (!tr.Drivers.Contains(this))
                    tr.Drivers.Add(this);
                LogisticSystem.Transports.Add(tr);
                if (!_transports.Contains(tr))
                    _transports.Add(tr);
            }
        }

        public void RemoveTransport(Transport tr)
        {
            _transports.Remove(tr);
            Driver temp;
            try
            {
                temp = LogisticSystem.Transports.First((t) => tr == t).Drivers.First((d) => d == this);
            }
            catch (InvalidOperationException)
            {
                temp = null;
            }
            
            if (temp != null)
                LogisticSystem.Transports.First((t) => tr == t).Drivers.Remove(temp);
            else
                LogisticSystem.Transports.Remove(tr);
        }

        public ObservableCollection<Transport> GetTransports()
        {
            return _transports;
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

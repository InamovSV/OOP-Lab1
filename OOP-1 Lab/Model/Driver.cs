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
        ObservableCollection<Transport> _transport;
        ObservableCollection<TransportRoute> _historyOfRouts;

        public Driver(string firstName, string lastName, string login, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Experience = 0;
            Transports = new ObservableCollection<Transport>();
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

        public ObservableCollection<Transport> Transports
        {
            get
            {
                return _transport;
            }
            private set
            {
                _transport = value;
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
                if (!(new Regex(@"@c$").IsMatch(value)))
                    _password = value;
                else
                    throw new ArgumentException("Invalid term in the expression");
            }
        }

        #endregion

    }
}

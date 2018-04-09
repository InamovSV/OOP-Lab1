using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace OOP_1_Lab.Model
{
    [DataContract]
    public class Driver : Base<Driver>, IUser
    {
        string _firstName;
        string _lastName;
        int _experience;
        int _earnings;
        string _phoneNumber;
        string _login;
        string _password;
        TransportRoute _currentRoute;
        ObservableCollection<TransportRoute> _historyOfRouts;

        public Driver(string firstName, string lastName, string login, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Experience = 0;
            Earnings = 0;
        }

        #region Properties
        [DataMember]
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
        [DataMember]
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
        [DataMember]
        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value >= 0)
                    _experience = value;
                else throw new ArgumentException();
            }
        }
        [DataMember]
        public int Earnings
        {
            get
            {
                return _earnings;
            }
            private set
            {
                _earnings = value;
            }
        }
        [DataMember]
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
        [DataMember]
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
        [DataMember]
        public string Login
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
        [DataMember]
        public string Password
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
        [DataMember]
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

        public ObservableCollection<Transport> Transports
        {
            get
            {
                ObservableCollection<Transport> listTr = new ObservableCollection<Transport>();
                foreach (var item in DriverTransportContext.Items.Values)

                    if (item.Driver == this)
                        listTr.Add(item.Transport);
                return listTr;
            }
        }

        #endregion

        //public void AddTransport(Transport tr)
        //{
        //    Transport tempTr;
        //    try
        //    {
        //        tempTr = LogisticSystem.Transports.First((t) => t.Equals(tr));
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        tempTr = null;
        //    }
        //    if (tempTr != null)
        //    {
        //        if (!tempTr.Drivers.Contains(this))
        //            tempTr.Drivers.Add(this);
        //        if (!_transports.Contains(tr))
        //            _transports.Add(tempTr);
        //    }
        //    else
        //    {
        //        if (!tr.Drivers.Contains(this))
        //            tr.Drivers.Add(this);
        //        LogisticSystem.Transports.Add(tr);
        //        if (!_transports.Contains(tr))
        //            _transports.Add(tr);
        //    }
        //}

        //public void RemoveTransport(Transport tr)
        //{
        //    _transports.Remove(tr);
        //    Driver temp;
        //    try
        //    {
        //        temp = LogisticSystem.Transports.First((t) => tr == t).Drivers.First((d) => d == this);
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        temp = null;
        //    }

        //    if (temp != null)
        //        LogisticSystem.Transports.First((t) => tr == t).Drivers.Remove(temp);
        //    else
        //        LogisticSystem.Transports.Remove(tr);
        //}

        //public ObservableCollection<Transport> GetTransports()
        //{
        //    return _transports;
        //}

        public void Pay(int value)
        {
            if (value >= 0)
                Earnings += value;
            else throw new ArgumentException("Argument must be above zero");
        }

        public override bool Equals(object obj)
        {
            if (obj is IUser)
                return Login == obj.ToString();
            else throw new ArgumentException();
        }

        public override int GetHashCode()
        {
            return Login.GetHashCode();
        }
    }
}

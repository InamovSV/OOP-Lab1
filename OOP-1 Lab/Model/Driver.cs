using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    class Driver : Base<Driver>
    {
        string _firstName;
        string _lastName;
        int _experience;
        List<Transport> _transport;

        public Driver(string firstName, string lastName, int experience)
        {
            FirstName = firstName;
            LastName = lastName;
            Experience = experience;
            _transport = new List<Transport>();
        }

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

        public List<Transport> Transport
        {
            get
            {
                return _transport;
            }
        }
    }
}

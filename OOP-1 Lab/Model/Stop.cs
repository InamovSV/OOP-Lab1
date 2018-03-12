using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    public class Stop : Base<Stop>
    {
        string _name;
        string _country;
        string _region;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null && value.Length < 100)
                    _name = value;
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                if (value != null && value.Length < 100)
                    _country = value;
            }
        }

        public string Region
        {
            get
            {
                return _region;
            }
            set
            {
                if (value != null && value.Length < 100)
                    _region = value;
            }
        }

        public Stop(string name, string country, string region)
        {
            Name = name;
            Country = country;
            Region = region;
        }

    }
}

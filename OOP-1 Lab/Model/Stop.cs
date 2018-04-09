using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace OOP_1_Lab.Model
{
    [DataContract]
    public class Stop : Base<Stop>
    {
        string _name;
        string _country;
        string _region;
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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

        public override string ToString()
        {
            return string.Format("Name: {0}\nCountry: {1}\nRegion: {2}", Name, Country, Region);
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}

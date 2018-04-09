using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    [DataContract]
    public class Plane : Transport
    {
        public enum Types
        {
            Airliner,
            CargoPlane
        }

        public Plane(string model, int carryingCapacity, int peopleCapacity, Plane.Types type) : base(model, carryingCapacity, peopleCapacity)
        {
            Type = type;
        }

        Types _type;
        int _carryingCapacity;
        int _peopleCapacity;
        [DataMember]
        public override int CarryingCapacity
        {
            get
            {
                return _carryingCapacity;
            }

            set
            {
                if (value != 0 && value > 0 && value < 10000)
                    _carryingCapacity = value;
            }
        }
        [DataMember]
        public override int PeopleCapacity
        {
            get
            {
                return _peopleCapacity;
            }

            set
            {
                if (value != 0 && value > 0 && value < 10000)
                    _peopleCapacity = value;
            }
        }
        [DataMember]
        public Types Type
        {
            get
            {
                return _type;
            }
            private set
            {
                _type = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}\nModel: {1}\nPeopleCapacity: {2}\nCarryingCapacity: {3}", Type, Model, PeopleCapacity, CarryingCapacity);
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}

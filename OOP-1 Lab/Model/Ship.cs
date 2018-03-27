using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    public class Ship : Transport
    {
        public enum Types
        {
            Liner,
            Tanker,
            Boat
        }

        public Ship(string model, int carryingCapacity, int peopleCapacity, Ship.Types type) : base(model, carryingCapacity, peopleCapacity)
        {
            Type = type;
        }

        Types _type;
        int _carryingCapacity;
        int _peopleCapacity;

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

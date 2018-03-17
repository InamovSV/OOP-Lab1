using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    class Train: Transport
    {
        public enum Types
        {
            Airliner,
            CargoPlane
        }

        public Train(string model, int carryingCapacity, int peopleCapacity, Train.Types type) : base(model, carryingCapacity, peopleCapacity)
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
    }
}

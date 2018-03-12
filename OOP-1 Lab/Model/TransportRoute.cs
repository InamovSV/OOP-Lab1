using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    class TransportRoute : Base<TransportRoute>
    {
        public TransportRoute() : this(new LinkedList<Stop>(), null, null)
        {
        }

        public TransportRoute(Stop startStop, Stop endStop, string targetOfRoute = null, int? distance = null)
        {
            Stops = new LinkedList<Stop>();
            Stops.AddLast(startStop);
            Stops.AddLast(endStop);
            TargetOfRoute = targetOfRoute;
            Distance = distance;
        }

        public TransportRoute(LinkedList<Stop> stops, string targetOfRoute = null, int? distance = null)
        {
            TargetOfRoute = targetOfRoute;
            Distance = distance;
            Stops = stops;
        }

        int? _distance;
        string _targetOfRoute;

        public string TargetOfRoute
        {
            get
            {
                return _targetOfRoute;
            }
            set
            {
                if (value.Length < 600)
                    _targetOfRoute = value;
            }
        }

        public LinkedList<Stop> Stops { get; }

        public Stop StartStop
        {
            get
            {
                if (Stops != null && Stops.Count != 0)
                    return Stops[0];
                else return null;
            }
        }

        public Stop EndStop
        {
            get
            {
                if (Stops != null && Stops.Count != 0)
                    return Stops[Stops.Count - 1];
                else return null;
            }
        }

        public int? Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                if (value != null && value > 0 && value < 1000000)
                    _distance = value;
                else if (value == null)
                    _distance = null;
                else throw new ArgumentException();
            }
        }


    }
}

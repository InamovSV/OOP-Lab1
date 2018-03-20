using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    public class TransportRoute : Base<TransportRoute>, IEnumerable<Stop>
    {
        int? _distance;
        string _targetOfRoute;

        public TransportRoute() : this(new List<Stop>(), null, null)
        {
        }

        public TransportRoute(Stop startStop, Stop endStop, string targetOfRoute = null, int? distance = null)
        {
            Stops = new List<Stop>();
            Stops.Add(startStop);
            Stops.Add(endStop);
            TargetOfRoute = targetOfRoute;
            Distance = distance;
        }

        public TransportRoute(List<Stop> stops, string targetOfRoute = null, int? distance = null)
        {
            TargetOfRoute = targetOfRoute;
            Distance = distance;
            Stops = stops;
        }
        
        public Stop this[int index]
        {
            get
            {
                if (index >= 0 && index < Stops.Count)
                {
                    return Stops[index];
                }
                else throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Stops.Count)
                {
                    Stops[index] = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }

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

        private List<Stop> Stops { get; set; }

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

        public void Add(Stop stop)
        {
            if (stop != null)
                Stops.Add(stop);
            else throw new ArgumentNullException();
        }

        public void Remove(Stop stop)
        {
            Stops.Remove(stop);
        }

        public Stop[] GetStopByCountry(string country)
        {
            List<Stop> listRes;
            if (country != null)
            {
                listRes = new List<Stop>();
            }
            else throw new ArgumentNullException();

            foreach (var stop in this.Stops)
            {
                if (stop.Country == country)
                    listRes.Add(stop);
            }
            return listRes.ToArray();
        }

        public Stop[] GetStopByRegion(string region)
        {
            List<Stop> listRes;
            if (this != null)
            {
                listRes = new List<Stop>();
            }
            else throw new ArgumentNullException();

            foreach (var stop in this.Stops)
            {
                if (stop.Region == region)
                    listRes.Add(stop);
            }
            return listRes.ToArray();
        }

        public Stop[] FindAll(Predicate<Stop> match)
        {
            return Stops.FindAll(match).ToArray();
        }

        public override string ToString()
        {
            if (Stops.Count == 0)
                return "";

            StringBuilder sBuilder = new StringBuilder();
            foreach (var item in Stops)
            {
                sBuilder.Append(item);
                sBuilder.Append(", ");
            }
            sBuilder.Remove(sBuilder.Length - 1, 1);
            return sBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public IEnumerator<Stop> GetEnumerator()
        {
            return ((IEnumerable<Stop>)Stops).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Stop>)Stops).GetEnumerator();
        }
    }
}

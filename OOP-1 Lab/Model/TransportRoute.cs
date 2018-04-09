using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.Model
{
    [DataContract(IsReference = true)]
    public class TransportRoute : Base<TransportRoute>, IEnumerable<Stop>
    {
        int? _distance;
        string _targetOfRoute;
        int _cost;
        bool _isConfirm;
        Driver _performer;
        bool _isStart;
        bool _isEnd;
        int _experienceLimit;
        Customer _owner;

        public TransportRoute() : this(null, new ObservableCollection<Stop>(), 0, null, null, 0)
        {
        }

        public TransportRoute(Customer owner, Stop startStop, Stop endStop, int cost, string targetOfRoute = null, int? distance = null, int experienceLimit = 0)
        {
            Stops = new ObservableCollection<Stop>();
            Stops.Add(startStop);
            Stops.Add(endStop);
            Cost = cost;
            _targetOfRoute = targetOfRoute;
            Distance = distance;
            ExperienceLimit = experienceLimit;
            Owner = owner;
            LogisticSystem.TransportRouts.Add(this);
        }

        public TransportRoute(Customer owner, ObservableCollection<Stop> stops, int cost, string targetOfRoute = null, int? distance = null, int experienceLimit = 0)
        {
            _targetOfRoute = targetOfRoute;
            Distance = distance;
            if (stops.Count != 1)
                Stops = stops;
            else
                throw new ArgumentException("Numbers of routes can't be 1");
            Cost = cost;
            ExperienceLimit = experienceLimit;
            Owner = owner;
            LogisticSystem.TransportRouts.Add(this);
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

        #region Properties
        [DataMember]
        public Driver Performer
        {
            get
            {
                return _performer;
            }
            set
            {
                if(value != null)
                    if (value.Experience >= ExperienceLimit)
                        _performer = value;
                    else
                        throw new ArgumentException("The driver do not passed the limit of experience");
            }
        }
        [DataMember]
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

        //To Do Если маршрут не завершен - запретить мутатор
        [DataMember]
        public ObservableCollection<Stop> Stops { get; set; }

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
        [DataMember]
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
        [DataMember]
        public int Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }
        //To Do продумать доступ к подтверждению
        [DataMember]
        public bool IsConfirm
        {
            get
            {
                return _isConfirm;
            }
            set
            {
                if (value == true)
                {
                    IsEnd = false;
                    IsStart = false;
                }
                _isConfirm = value;
            }
        }
        [DataMember]
        public bool IsStart
        {
            get
            {
                return _isStart;
            }

            set
            {
                if (IsEnd && value == false)
                    throw new ArgumentException("Do not right argument's logic");
                else
                {
                    _isStart = value;
                }
                    
            }
        }
        [DataMember]
        public bool IsEnd
        {
            get
            {
                return _isEnd;
            }

            set
            {
                if (!IsStart && value == true)
                    throw new ArgumentException("Do not right argument's logic");
                else
                    _isEnd = value;

            }
        }
        [DataMember]
        public int ExperienceLimit
        {
            get
            {
                return _experienceLimit;
            }

            set
            {
                _experienceLimit = value;
            }
        }
        [DataMember]
        public Customer Owner
        {
            get
            {
                return _owner;
            }

            set
            {
                _owner = value;
            }
        }


        #endregion

        #region Methods

        //public Stop[] GetStopByCountry(string country)
        //{
        //    ObservableCollection<Stop> ObservableCollectionRes;
        //    if (country != null)
        //    {
        //        ObservableCollectionRes = new ObservableCollection<Stop>();
        //    }
        //    else throw new ArgumentNullException();

        //    foreach (var stop in this.Stops)
        //    {
        //        if (stop.Country == country)
        //            ObservableCollectionRes.Add(stop);
        //    }
        //    return ObservableCollectionRes.ToArray();
        //}

        //public Stop[] GetStopByRegion(string region)
        //{
        //    ObservableCollection<Stop> ObservableCollectionRes;
        //    if (this != null)
        //    {
        //        ObservableCollectionRes = new ObservableCollection<Stop>();
        //    }
        //    else throw new ArgumentNullException();

        //    foreach (var stop in this.Stops)
        //    {
        //        if (stop.Region == region)
        //            ObservableCollectionRes.Add(stop);
        //    }
        //    return ObservableCollectionRes.ToArray();
        //}

        //public Stop[] FindAll(Predicate<Stop> match)
        //{
        //    return Stops.FindAll(match).ToArray();
        //}

        public string ToStringAllStops()
        {
            if (Stops.Count == 0)
                return "Stop is absent";

            StringBuilder sBuilder = new StringBuilder();
            foreach (var item in Stops)
            {
                sBuilder.Append(item);
                sBuilder.Append(", ");
            }
            sBuilder.Remove(sBuilder.Length - 1, 1);
            return sBuilder.ToString();
        }

        public override string ToString()
        {
            if (Stops.Count == 0)
                return "";
            return Stops[0].Name + " - " + Stops[Stops.Count - 1].Name;
        }

        public IEnumerator<Stop> GetEnumerator()
        {
            return ((IEnumerable<Stop>)Stops).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Stop>)Stops).GetEnumerator();
        }
        #endregion

    }
}

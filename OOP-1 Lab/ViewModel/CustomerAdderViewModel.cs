using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OOP_1_Lab.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Lab.ViewModel
{
    public class CustomerAdderViewModel : ViewModelBase
    {
        string _targetOfRoute;
        int? _distance;
        int _experience;
        int _cost;
        string _country;
        string _region;
        string _nameStop;
        Stop _currentStop;
        ObservableCollection<Stop> _stops;
        RelayCommand _addRoute;
        RelayCommand _addStop;

        #region Properties
        public string TargetOfRoute
        {
            get
            {
                return _targetOfRoute;
            }

            set
            {
                _targetOfRoute = value;
                RaisePropertyChanged("TargetOfRoute");
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
                _distance = value;
                RaisePropertyChanged("Distance");
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
                _experience = value;
                RaisePropertyChanged("Experience");
            }
        }

        public int Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost = value;
                RaisePropertyChanged("Cost");
            }
        }

        public Stop CurrentStop
        {
            get
            {
                return _currentStop;
            }

            set
            {
                _currentStop = value;
                RaisePropertyChanged("CurrentStop");
            }
        }

        public ObservableCollection<Stop> Stops
        {
            get
            {
                if (_stops == null)
                    _stops = new ObservableCollection<Stop>();
                return _stops;
            }

            set
            {
                _stops = value;
                RaisePropertyChanged("Stops");
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
                _country = value;
                RaisePropertyChanged("Country");
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
                _region = value;
                RaisePropertyChanged("Region");
            }
        }

        public string NameStop
        {
            get
            {
                return _nameStop;
            }

            set
            {
                _nameStop = value;
                RaisePropertyChanged("NameStop");
            }
        }
        #endregion


        public RelayCommand AddRoute
        {
            get
            {
                if (_addRoute == null)
                    _addRoute = new RelayCommand(() =>
                    {
                        App.CustomerViewModel.CurrentCustomer.Routs.Add(new TransportRoute(App.CustomerViewModel.CurrentCustomer, Stops, Cost, TargetOfRoute, Distance, Experience));
                        TargetOfRoute = null;
                        Distance = null;
                        Experience = 0;
                        Cost = 0;
                        Stops = null;
                        Country = null;
                        Region = null;
                    });
                return _addRoute;
            }
        }

        public RelayCommand AddStop
        {
            get
            {
                if (_addStop == null)
                    _addStop = new RelayCommand(() =>
                    {
                        Stops.Add(new Stop(NameStop, Country, Region));
                        NameStop = null;
                    }, () =>
                    {
                        return NameStop != "" && NameStop != null && Country != "" && Country != null && Region != "" && Region != "";
                    });
                return _addStop;
            }
        }


    }
}

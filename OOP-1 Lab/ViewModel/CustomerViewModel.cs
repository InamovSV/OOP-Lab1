using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OOP_1_Lab.Model;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

namespace OOP_1_Lab.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        public CustomerViewModel()
        {

        }
        #region Properties
        Customer _currentCustomer;
        public Customer CurrentCustomer
        {
            get
            {
                return _currentCustomer;
            }
            set
            {
                _currentCustomer = value;
                RaisePropertyChanged("CurrentCustomer");
            }
        }

        ObservableCollection<Transport> _transports;
        public ObservableCollection<Transport> Transports
        {
            get
            {
                if (_transports == null)
                    _transports = CurrentCustomer.Transports;

                return _transports;
            }
        }

        Transport _selectTransport;
        public Transport SelectTransport
        {
            get
            {
                return _selectTransport;
            }
            set
            {
                _selectTransport = value;
                RaisePropertyChanged("SelectTransport");
            }
        }

        Driver _selectDriver;
        public Driver SelectDriver
        {
            get
            {
                return _selectDriver;
            }
            set
            {
                _selectDriver = value;
                RaisePropertyChanged("SelectDriver");
            }
        }

        TransportRoute _selectRoute;
        public TransportRoute SelectRoute
        {
            get
            {
                return _selectRoute;
            }

            set
            {
                _selectRoute = value;
                RaisePropertyChanged("SelectRoute");
                RaisePropertyChanged("SelectRouteStatus");
            }
        }

        string _selectRouteStatus;
        public string SelectRouteStatus
        {
            get
            {
                if (SelectRoute.IsEnd)
                {
                    _selectRouteStatus = "Awaits confirmation";
                }
                else if(SelectRoute.IsStart && !SelectRoute.IsEnd)
                {
                    _selectRouteStatus = "On the way";
                }
                else
                {
                    _selectRouteStatus = "Free";
                }
                return _selectRouteStatus;
            }

            private set
            {
                _selectRouteStatus = value;
                RaisePropertyChanged("SelectRouteStatus");
            }
        }
        #endregion


        #region Commands
        RelayCommand _goOut;
        public RelayCommand GoOut
        {
            get
            {
                if (_goOut == null)
                    _goOut = new RelayCommand(() =>
                    {
                        CurrentCustomer = null;
                    });
                return _goOut;
            }
        }
        #endregion
 
    }
}

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OOP_1_Lab.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_1_Lab.ViewModel
{
    public class DriverViewModel : ViewModelBase
    {
        public DriverViewModel()
        {
            DriverVisibility = Visibility.Hidden;
        }

        Driver _currentDriver;
        string _druverStatus;

        Visibility _driverVisibility;
        public Visibility DriverVisibility
        {
            get
            {
                return _driverVisibility;
            }
            set
            {
                _driverVisibility = value;
                RaisePropertyChanged("DriverVisibility");
            }
        }
        //To do пропадает ссылка на CurrentDriver
        public Driver CurrentDriver
        {
            get
            {
                return _currentDriver;
            }
            set
            {
                _currentDriver = value;
                RaisePropertyChanged("CurrentDriver");
                RaisePropertyChanged("DruverStatus");
            }
        }

        public string DriverStatus
        {
            get
            {
                if (CurrentDriver.CurrentRoute.IsStart == false)
                    _druverStatus = "Free";
                else if (CurrentDriver.CurrentRoute.IsStart && !CurrentDriver.CurrentRoute.IsEnd)
                    _druverStatus = "On the way";
                return _druverStatus;
            }
        }

        public ObservableCollection<TransportRoute> TransportRoutes
        {
            get
            {
                return LogisticSystem.TransportRouts;
            }
        }

        RelayCommand _logOut;
        public RelayCommand LogOut
        {
            get
            {
                if (_logOut == null)
                    _logOut = new RelayCommand(() =>
                    {
                        CurrentDriver = null;
                    });
                return _logOut;
            }
        }
    }
}

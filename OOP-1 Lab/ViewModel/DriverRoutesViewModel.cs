using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_1_Lab.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

namespace OOP_1_Lab.ViewModel
{
    class DriverRoutesViewModel : ViewModelBase
    {
        RelayCommand _start;
        TransportRoute _currentRoute;

        public TransportRoute CurrentRoute
        {
            get
            {
                return _currentRoute;
            }

            set
            {
                _currentRoute = value;
                RaisePropertyChanged("CurrentRoute");
            }
        }

        public RelayCommand Start
        {
            get
            {
                if (_start == null)
                    _start = new RelayCommand(() =>
                    {
                        App.DriverViewModel.CurrentDriver.CurrentRoute = CurrentRoute;
                        LogisticSystem.TransportRouts.Remove(CurrentRoute);
                    });
                return _start;
            }
        }

        
    }
}

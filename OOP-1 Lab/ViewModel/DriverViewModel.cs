using GalaSoft.MvvmLight;
using OOP_1_Lab.Model;
using System;
using System.Collections.Generic;
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
                RaisePropertyChanged("AdminVisibility");
            }
        }

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
            }
        }
    }
}

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
    public class AdminViewModel : ViewModelBase
    {
        public AdminViewModel()
        {
            AdminVisibility = Visibility.Hidden;
            AddClient = new RelayCommand(() =>
            {

            });
        }

        public RelayCommand AddClient
        {
            get;
            private set;
        }
        Customer _currentAdmin;
        public Customer CurrentAdmin
        {
            get
            {
                return _currentAdmin;
            }
            set
            {
                _currentAdmin = value;
                RaisePropertyChanged("CurrentAdmin");
            }
        }
        //Admin admin = new Admin();
        string _login;
        string _password;
        public string Login
        {
            get
            {
                return CurrentAdmin.Login;
            }
            set
            {
                CurrentAdmin.Login = value;
                RaisePropertyChanged("Login");
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }
        Visibility _adminvisibility;
        public Visibility AdminVisibility
        {
            get
            {
                return _adminvisibility;
            }
            set
            {
                _adminvisibility = value;
                RaisePropertyChanged("AdminVisibility");
            }
        }

        ObservableCollection<Transport> _transports;
        public ObservableCollection<Transport> Transports
        {
            get
            {
                if (_transports == null)
                    _transports = CurrentAdmin.Transports;
                
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

        ObservableCollection<Driver> _drivers;
        public ObservableCollection<Driver> Drivers
        {
            get
            {
                if (_drivers == null && SelectTransport != null)
                    _drivers = SelectTransport.Drivers;
                return _drivers;
            }
        }
    }
}

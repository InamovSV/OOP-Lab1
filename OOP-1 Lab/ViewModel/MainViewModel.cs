using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using OOP_1_Lab.Model;

namespace OOP_1_Lab.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                RaisePropertyChanged("Login");
            }
        }

        Visibility _visibilityLogin;
        public Visibility VisibilityLogin
        {
            get
            {
                return _visibilityLogin;
            }
            set
            {
                _visibilityLogin = value;
                RaisePropertyChanged("VisibilityLogin");
            }
        }
        //Admin _admin;
        //public Admin CurrrentAdmin
        //{
        //    get
        //    {
        //        return _admin;
        //    }
        //    set
        //    {
        //        _admin = value;
        //        RaisePropertyChanged("Administator");
        //    }
        //}

        //Driver _currentDriver;
        //public Driver CurrentDriver
        //{
        //    get
        //    {
        //        return _currentDriver;
        //    }
        //    set
        //    {
        //        _currentDriver = value;
        //        RaisePropertyChanged("CurrentDriver");
        //    }
        //}

        RelayCommand _signIn;
        public RelayCommand SignIn
        {
            get
            {
                return _signIn ?? new RelayCommand(() => 
                {
                    //App.AdminViewModel.CurrentAdmin = new Customer(Login);
                    VisibilityLogin = Visibility.Hidden;
                    App.AdminViewModel.AdminVisibility = Visibility.Visible;
                });
            }
            private set
            {
                _signIn = value;
            }
        }
    }
}

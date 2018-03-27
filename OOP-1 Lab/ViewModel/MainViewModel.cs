using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using OOP_1_Lab.Model;
using System.Text.RegularExpressions;

namespace OOP_1_Lab.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        string _login;
        string _password;
        string _pattern = @"@c$";
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

        Visibility _visibilityChose;
        public Visibility VisibilityChose
        {
            get
            {
                return _visibilityChose;
            }

            set
            {
                _visibilityChose = value;
                RaisePropertyChanged("VisibilityChose");
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
            }
        }

        RelayCommand _signIn;
        public RelayCommand SignIn
        {
            get
            {
                return _signIn ?? new RelayCommand(() =>
                {
                    if (new Regex(_pattern).IsMatch(Login))
                    {
                        App.CustomerViewModel.CurrentCustomer = LogisticSystem.GetCustomer(Login, Password);
                        VisibilityLogin = Visibility.Hidden;
                        App.CustomerViewModel.CustomerVisibility = Visibility.Visible;
                    }
                    else
                    {
                        App.DriverViewModel.CurrentDriver = LogisticSystem.GetDriver(Login, Password);
                        VisibilityLogin = Visibility.Hidden;
                        App.DriverViewModel.DriverVisibility = Visibility.Visible;
                    }
                });
            }
            private set
            {
                _signIn = value;
            }
        }

        RelayCommand _signUp;
        public RelayCommand SignUp
        {
            get
            {
                return _signUp ?? new RelayCommand(() =>
                {
                    
                });
            }
            private set
            {
                _signIn = value;
            }
        }

    }
}

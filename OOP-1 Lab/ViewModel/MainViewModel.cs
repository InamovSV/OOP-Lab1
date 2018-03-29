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

        public MainViewModel()
        {
            VisibilityChose = Visibility.Hidden;
            VisibilityNames = Visibility.Hidden;
        }
        #region Properties

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

        Visibility _visibilityNames;
        public Visibility VisibilityNames
        {
            get
            {
                return _visibilityNames;
            }

            set
            {
                _visibilityNames = value;
                RaisePropertyChanged("VisibilityNames");
            }
        }

        Visibility _visibilityLastName;
        public Visibility VisibilityLastName
        {
            get
            {
                return _visibilityLastName;
            }

            set
            {
                _visibilityLastName = value;
                RaisePropertyChanged("VisibilityLastName");
            }
        }

        string _firstNameLabel;
        public string FirstNameLabel
        {
            get
            {
                return _firstNameLabel;
            }

            set
            {
                _firstNameLabel = value;
                RaisePropertyChanged("FirstNameLabel");
            }
        }

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

        private string firstName;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string _lastName;

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        bool _isValid;
        public bool IsValid
        {
            get
            {
                return _isValid;
            }

            private set
            {
                _isValid = value;
            }
        }
        #endregion

        #region Commands

        RelayCommand _signUp;
        public RelayCommand SignUp
        {
            get
            {
                if (_signUp == null)
                    _signUp = new RelayCommand(() =>
                    {
                        VisibilityChose = Visibility.Visible;
                    });
                return _signUp;
            }
        }

        RelayCommand _signUpCustomer;
        public RelayCommand SignUpCustomer
        {
            get
            {
                if (_signUpCustomer == null)
                    _signUpCustomer = new RelayCommand(() =>
                    {
                        FirstNameLabel = "Name";
                        VisibilityNames = Visibility.Visible;
                        VisibilityLastName = Visibility.Hidden;
                    });
                return _signUpCustomer;
            }
        }

        RelayCommand _signUpDriver;
        public RelayCommand SignUpDriver
        {
            get
            {
                if (_signUpDriver == null)
                    _signUpDriver = new RelayCommand(() =>
                    {
                        FirstNameLabel = "First name";
                        VisibilityNames = Visibility.Visible;
                        VisibilityLastName = Visibility.Visible;
                    });
                return _signUpDriver;
            }
        }

        RelayCommand _confirm;
        public RelayCommand Confirm
        {
            get
            {
                if (_confirm == null)
                    _confirm = new RelayCommand(() =>
                    {
                        try
                        {
                            if (FirstName != null && LastName == null)
                            {
                                LogisticSystem.AddCustomer(FirstName, Login, Password);
                                App.CustomerViewModel.CurrentCustomer = LogisticSystem.GetCustomer(Login, Password);
                                FirstName = null;
                            }
                            else if (FirstName != null && LastName != null)
                            {
                                LogisticSystem.AddDriver(FirstName, LastName, Login, Password);
                                App.DriverViewModel.CurrentDriver = LogisticSystem.GetDriver(Login, Password);
                                FirstName = null;
                                LastName = null;
                            }
                        }
                        catch (ArgumentException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    });
                return _confirm;
            }
        }
        #endregion
    }
}

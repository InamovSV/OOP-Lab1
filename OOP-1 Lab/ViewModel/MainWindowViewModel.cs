using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_1_Lab.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace OOP_1_Lab.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            AddClient = new RelayCommand(() => { Prop = "1"; Messenger.Default.Send("show"); });
        }
        public RelayCommand AddClient
        {
            get;
            private set;
        }
        string _prop;
        public string Prop
        {
            get
            {
                return _prop;
            }
            set
            {
                _prop = value;
                RaisePropertyChanged("Prop");
            }
        }
        Admin admin = new Admin();
        void Method()
        {
            
        }
    }
}

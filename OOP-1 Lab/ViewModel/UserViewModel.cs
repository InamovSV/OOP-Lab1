using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace OOP_1_Lab.ViewModel
{
    class UserViewModel : ViewModelBase
    {
        string _textForWindow;
        public string TextForWindow
        {
            get
            {
                return _textForWindow;
            }
            set
            {
                _textForWindow = value;
                RaisePropertyChanged(this.TextForWindow.GetType().Name);
            }
        }
        
    }
}

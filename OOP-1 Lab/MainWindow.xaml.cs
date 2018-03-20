using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using OOP_1_Lab.ViewModel;

namespace OOP_1_Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserWindow userWindow = new UserWindow();
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register(this, new Action<string>(ProcessMessage));
        }

        public void ProcessMessage(string msg)
        {
            var window = new UserWindow();
            if (msg == "show")
            {
                var model = window.DataContext as UserViewModel;
                if (model != null)
                {
                    model.TextForWindow = msg;
                }
                window.ShowDialog();
            }
            else if(msg == "close")
            {
                window.Close();
            }
        }


    }
}

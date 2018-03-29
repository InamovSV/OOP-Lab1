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
using GalaSoft.MvvmLight;
using System.Threading;
using System.Text.RegularExpressions;
using OOP_1_Lab.Model;

namespace OOP_1_Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height = 210;
            DataContext = App.MainWindowViewModel;
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbFN.Text != null && tbLN.Text == "" || tbLN.Text == null)
            {
                CustomerWindow cw = new CustomerWindow();
                cw.Show();
                Close();
            }
            else if (tbFN.Text != null && tbLN.Text != null)
            {
                DriverWindow dw = new DriverWindow();
                dw.Show();
                Close();
            }

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.Height = 362;
        }
        string _pattern = @"@c$";
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (new Regex(_pattern).IsMatch(tbLogin.Text))
            {
                try
                {
                    App.CustomerViewModel.CurrentCustomer = LogisticSystem.GetCustomer(tbLogin.Text, tbPassword.Text);
                    CustomerWindow cw = new CustomerWindow();
                    cw.Show();
                    Close();
                }
                catch (ArgumentException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                try
                {
                    App.DriverViewModel.CurrentDriver = LogisticSystem.GetDriver(tbLogin.Text, tbPassword.Text);
                    DriverWindow dw = new DriverWindow();
                    dw.Show();
                    Close();
                }
                catch (ArgumentException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

        }
    }
}

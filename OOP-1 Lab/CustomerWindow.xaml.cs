using OOP_1_Lab.Model;
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
using System.Windows.Shapes;

namespace OOP_1_Lab
{
    /// <summary>
    /// Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
            grMainCustomer.DataContext = App.CustomerViewModel;
            groupBoxAdder.Visibility = Visibility.Hidden;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            MainWindow mw = new MainWindow();
            this.Close();
            
            mw.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (groupBoxAdder.Visibility == Visibility.Hidden)
                groupBoxAdder.Visibility = Visibility.Visible;
            else
                groupBoxAdder.Visibility = Visibility.Hidden;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            LogisticSystem.SaveAll();
        }
    }
}

﻿using System;
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
            DataContext = App.MainWindowViewModel;
            gbCustomer.DataContext = App.CustomerViewModel;
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
        }
        
    }
}

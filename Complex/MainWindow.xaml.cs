﻿using Complex.Pages;
using System.Windows;

namespace Complex
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ComplexDBEntities db = new ComplexDBEntities();
        public MainWindow()
        {
            InitializeComponent();
            Navigation.main = this;
            MainFrame.Navigate(new ComplexListPage());
        }
    }
}

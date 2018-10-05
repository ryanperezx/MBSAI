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
using System.Windows.Shapes;
using MahApps.Metro.Controls;


namespace MBSAI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new Main().ShowDialog();
            ShowDialog();
        }

        private void lblForgot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
            Hide();
            new ForgotPassword().ShowDialog();
            ShowDialog();
        }
    }
}

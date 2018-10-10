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

namespace MBSAI
{
    /// <summary>
    /// Interaction logic for ExpiringInvent.xaml
    /// </summary>
    public partial class ExpiringInvent : Page
    {
        public ExpiringInvent()
        {
            InitializeComponent();
            fromDate.Text = DateTime.Today.ToString("d");

        }

        private void Generate_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string to = toDate.Text;
            string from = fromDate.Text;
            string inventType = cmbInventType.Text;
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(inventType))
            {
                MessageBox.Show("One or more fields is empty!");

            }
            else
            {
                this.NavigationService.Navigate(new ExpiringInventoryReport(from, inventType, to));
            }
        }

        private void fromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateCheck = DateTime.Today;
            if (fromDate.Text != dateCheck.ToString("d"))
            {
                toDate.Visibility = Visibility.Visible;
                lblDate.Visibility = Visibility.Visible;
            }
            else
            {
                toDate.Visibility = Visibility.Hidden;
                lblDate.Visibility = Visibility.Hidden;
            }
        }
    }
}

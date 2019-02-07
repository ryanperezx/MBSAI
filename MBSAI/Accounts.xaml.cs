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
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MBSAI
{
    /// <summary>
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : Page
    {
        public string passwordStatus;

        public Accounts()
        {
            InitializeComponent();
        }



        private void emptyFields()
        {
            txtUser.Text = null;
            txtPass.Password = null;
            txtConfirmPass.Password = null;
            cmbQuestion.SelectedIndex = -1;
            txtAns.Password = null;
        }

        private void Label_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Refresh();
        }

        private void searchUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Password must contain at least 8 characters, 1 uppercase, 1 numeric
            Regex reg = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");
            bool result = reg.IsMatch(txtPass.Password.ToString());

            if (result)
            {
                passwordStatus = "Password is Valid";
                lblPassword.Content = passwordStatus;
                lblPassword.Foreground = Brushes.Green;
            }
            else
            {
                passwordStatus = "Password is Invalid";
                lblPassword.Content = passwordStatus;
                lblPassword.Foreground = Brushes.Red;
            }
            if (string.IsNullOrEmpty(txtPass.Password))
            {
                lblPassword.Content = null;
            }
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string PasswordStatus
        {
            get { return passwordStatus; }
            set
            {
                passwordStatus = value;
                OnPropertyChanged();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

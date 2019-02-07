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
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;

namespace MBSAI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        public static string userLevel;
        string user;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("One or more fields are empty!");
                return;
            }
            else
            {
                var conn = DBUtils.Instance();
                conn.IsConnect();
                Nullable<int> loginAttempts;

                using (MySqlCommand cmd = new MySqlCommand("Select tries FROM Accounts WHERE username = @username", conn.Connection))
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    loginAttempts = Convert.ToInt32(cmd.ExecuteScalar());
                }
                if (loginAttempts < 5)
                {
                    string un = txtUsername.Text;
                    string pw = txtPassword.Password;

                    using (MySqlCommand cmd = new MySqlCommand("Select * from Accounts where username = @username AND password = @password", conn.Connection))
                    {
                        cmd.Parameters.AddWithValue("@username", un);
                        cmd.Parameters.AddWithValue("@password", pw);
                        MySqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string lName, fName, mName;
                            lName = dr.GetString(2);
                            fName = dr.GetString(3);
                            mName = dr.GetString(4);
                            int userLevelIndex = dr.GetOrdinal("accountLvl");
                            userLevel = dr.GetString(userLevelIndex);

                            using (MySqlCommand cmd2 = new MySqlCommand("UPDATE Accounts SET tries = 0", conn.Connection))
                            {
                                dr.Close();
                                dr.Dispose();
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Login Successful");
                            }

                        }

                        else
                        {
                            using (MySqlCommand cmd2 = new MySqlCommand("Select username from Accounts where username = @username", conn.Connection))
                            {
                                cmd2.Parameters.AddWithValue("@username", un);
                                dr.Close();
                                dr.Dispose();
                                dr = cmd2.ExecuteReader();
                                int ordinal = 0;
                                string value = "";

                                if (dr.Read())
                                {
                                    ordinal = dr.GetOrdinal("username");
                                    value = dr.GetString(ordinal);
                                    if (value.Equals(un))
                                    {
                                        using (MySqlCommand cmd3 = new MySqlCommand("UPDATE Accounts SET tries = tries + 1 WHERE username = @username", conn.Connection))
                                        {
                                            cmd3.Parameters.AddWithValue("@username", un);
                                            dr.Close();
                                            dr.Dispose();
                                            cmd3.ExecuteNonQuery();
                                            cmd3.Dispose();
                                        }
                                    }
                                }
                            }
                            MessageBox.Show("Username or Password is invalid");
                            return;
                        }
                    }
                    Hide();
                    new Main().ShowDialog();
                    ShowDialog();
                    txtPassword.Password = null;
                    txtUsername.Text = null;
                }
                else
                {
                    user = txtUsername.Text;
                    string sMessageBoxText = "Due to multiple login attempts, your account has been locked. \nPlease unlock it to continue.";
                    string sCaption = "Account Recovery";
                    MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                    MessageBoxResult dr = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                    switch (dr)
                    {
                        case MessageBoxResult.Yes:
                            Hide();
                            new ForgotPassword(txtUsername.Text).ShowDialog();
                            ShowDialog();
                            break;

                        case MessageBoxResult.No: break;
                    }
                }
            }
        }

        private void lblForgot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("No username input");
                txtUsername.Focus();
            }
            else
            {
                var conn = DBUtils.Instance();
                conn.IsConnect();
                using (MySqlCommand cmd = new MySqlCommand("Select COUNT(1) from Accounts where username = @username", conn.Connection))
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        Hide();
                        new ForgotPassword(txtUsername.Text).ShowDialog();
                        ShowDialog();
                        txtPassword.Password = null;
                        txtUsername.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("User does not exist!");

                    }
                }
            }
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.FontStyle = FontStyles.Normal;
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.FontStyle = FontStyles.Normal;
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.FontStyle = FontStyles.Italic;
            }
            else
            {
                txtUsername.FontStyle = FontStyles.Normal;

            }
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Password))
            {
                txtPassword.FontStyle = FontStyles.Italic;
            }
            else
            {
                txtUsername.FontStyle = FontStyles.Normal;
            }
        }
    }
}

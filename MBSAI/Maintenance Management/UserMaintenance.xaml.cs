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

namespace MBSAI
{
    /// <summary>
    /// Interaction logic for UserMaintenance.xaml
    /// </summary>
    public partial class UserMaintenance : Page
    {
        public UserMaintenance()
        {
            InitializeComponent();

            GridViewUserEmployee emp1 = new GridViewUserEmployee();
            emp1.Code = "USR001";
            emp1.Desc = "Joann Suriaga";
            emp1.Role = "IT Admin";
            emp1.startDate = DateTime.Now.ToString("D");
            emp1.enabled = true;
            emp1.locked = false;

            dgUserMaintenance.Items.Add(emp1);

            GridViewUserEmployee emp2 = new GridViewUserEmployee();
            emp2.Code = "USR002";
            emp2.Desc = "Marinette Salutan";
            emp2.Role = "Nurse 1";
            emp2.startDate = DateTime.Now.ToString("D");
            emp2.enabled = true;
            emp2.locked = false;

            dgUserMaintenance.Items.Add(emp2);
        }

        private void Add_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new UserMaintenanceDetails());
        }

        private void Reload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

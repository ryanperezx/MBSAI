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
    /// Interaction logic for RoleMaintenance.xaml
    /// </summary>
    public partial class RoleMaintenance : Page
    {
        public RoleMaintenance()
        {
            InitializeComponent();
            GridViewReferenceData item1 = new GridViewReferenceData();
            item1.Code = "ROL001";
            item1.Desc = "IT Admin";
            item1.startDate = DateTime.Now.ToString("dd MMMM yyyy");
            item1.endDate = DateTime.Now.ToString("dd MMMM yyyy");
            item1.active = true;
            item1.used = true;

            dgRoleMaintenance.Items.Add(item1);

            GridViewReferenceData item2 = new GridViewReferenceData();
            item2.Code = "ROL002";
            item2.Desc = "Nurse 1";
            item2.startDate = DateTime.Now.ToString("dd MMMM yyyy");
            item2.endDate = DateTime.Now.ToString("dd MMMM yyyy");
            item2.active = false;
            item2.used = true;

            dgRoleMaintenance.Items.Add(item2);
        }

        private void Add_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new RoleMaintenanceRecord());
        }

        private void Reload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for EmployeeMaintenance.xaml
    /// </summary>
    public partial class EmployeeMaintenance : Page
    {
        public EmployeeMaintenance()
        {
            InitializeComponent();
            GridViewEmployeeMaintenance item1 = new GridViewEmployeeMaintenance();
            item1.Code = "EMP001";
            item1.empName = "Tankiang Angelita L.";
            item1.department = "Information Technology";
            item1.startDate = DateTime.Now.ToString("dd MMMM yyyy");
            item1.endDate = DateTime.Now.ToString("dd MMMM yyyy");
            item1.active = true;

            dgEmpMaintenance.Items.Add(item1);

            GridViewEmployeeMaintenance item2 = new GridViewEmployeeMaintenance();
            item2.Code = "ROL002";
            item2.empName = "Balce Rizaldy E.";
            item2.department = "Clinic";
            item2.startDate = DateTime.Now.ToString("dd MMMM yyyy");
            item2.endDate = DateTime.Now.ToString("dd MMMM yyyy");
            item2.active = false;

            dgEmpMaintenance.Items.Add(item2);
        }

        private void Add_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new EmployeeMaintenanceRecord());
        }

        private void Reload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

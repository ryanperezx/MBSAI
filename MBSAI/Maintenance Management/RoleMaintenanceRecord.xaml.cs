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
    /// Interaction logic for RoleMaintenanceRecord.xaml
    /// </summary>
    public partial class RoleMaintenanceRecord : Page
    {
        public RoleMaintenanceRecord()
        {
            InitializeComponent();

            GridViewReferenceData item1 = new GridViewReferenceData();
            item1.Code = "PRV001";
            item1.Desc = "Reference Data";
            item1.startDate = DateTime.Now.ToString("D");
            item1.endDate = DateTime.Now.ToString("D");
            item1.active = true;
            item1.used = false;

            dgMaintenace.Items.Add(item1);

            GridViewReferenceData item2 = new GridViewReferenceData();
            item2.Code = "PRV002";
            item2.Desc = "Stock In";
            item2.startDate = DateTime.Now.ToString("D");
            item2.endDate = DateTime.Now.ToString("D");
            item2.active = false;
            item2.used = true;

            dgMaintenace.Items.Add(item2);
        }

        private void imgBack_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string sMessageBoxText = "Close screen without saving?";
            string sCaption = "Warning";
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult dr = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (dr)
            {
                case MessageBoxResult.Yes:
                    this.NavigationService.Navigate(new RoleMaintenance());
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}

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
    /// Interaction logic for MedicalSupplies.xaml
    /// </summary>
    public partial class MedicalSupplies : Page
    {
        public MedicalSupplies()
        {
            InitializeComponent();
            GridViewReferenceData item1 = new GridViewReferenceData();
            item1.Code = "MES001";
            item1.Desc = "Magnifying Glass";
            item1.startDate = DateTime.Now.ToString("D");
            item1.endDate = DateTime.Now.ToString("D");
            item1.active = true;
            item1.used = false;

            dgMedSupp.Items.Add(item1);

            GridViewReferenceData item2 = new GridViewReferenceData();
            item2.Code = "MES002";
            item2.Desc = "Non-latex cleaning gloves";
            item2.startDate = DateTime.Now.ToString("D");
            item2.endDate = DateTime.Now.ToString("D");
            item2.active = false;
            item2.used = true;

            dgMedSupp.Items.Add(item2);
        }

        private void Add_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MedicalSuppliesRecord());
        }

        private void Reload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

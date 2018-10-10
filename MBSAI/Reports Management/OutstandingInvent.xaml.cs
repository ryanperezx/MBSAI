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
    /// Interaction logic for OutstandingInvent.xaml
    /// </summary>
    public partial class OutstandingInvent : Page
    {
        public OutstandingInvent()
        {
            InitializeComponent();
        }

        private void Generate_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(date.Text))
            {
                MessageBox.Show("Please input date to the missing field");
                date.Focus();
            }
            else
            {
                this.NavigationService.Navigate(new OutstandingInventReport(date.Text));
            }
        }
    }
}

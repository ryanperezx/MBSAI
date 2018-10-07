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
    /// Interaction logic for MedicalEquipmentRecord.xaml
    /// </summary>
    public partial class MedicalEquipmentRecord : Page
    {
        public MedicalEquipmentRecord()
        {
            InitializeComponent();
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
                    this.NavigationService.Navigate(new MedicalEquipment());
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void imgBack_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

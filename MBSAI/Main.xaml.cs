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

namespace MBSAI
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            date.Content = DateTime.Now.ToString("D");
        }

        private void lblLogOut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string sMessageBoxText = "Do you want to log out?";
            string sCaption = "Logout";
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult dr = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (dr)
            {
                case MessageBoxResult.Yes:
                    this.DialogResult = false;
                    Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void lblInvent_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Inventory Type!");
        }

        private void lblMedSup_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Medical Supplies!");
        }

        private void lblInvent_MouseEnter(object sender, MouseEventArgs e)
        {
            lblInvent.TextDecorations = TextDecorations.Underline;
        }

        private void lblInvent_MouseLeave(object sender, MouseEventArgs e)
        {
            lblInvent.TextDecorations = null;
        }

        private void lblMedEqp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblMedEqp_MouseEnter(object sender, MouseEventArgs e)
        {
            lblMedEqp.TextDecorations = TextDecorations.Underline;
        }

        private void lblMedEqp_MouseLeave(object sender, MouseEventArgs e)
        {
            lblMedEqp.TextDecorations = null;

        }

        private void lblMedSup_MouseEnter(object sender, MouseEventArgs e)
        {
            lblMedSup.TextDecorations = TextDecorations.Underline;
        }

        private void lblMedSup_MouseLeave(object sender, MouseEventArgs e)
        {
            lblMedSup.TextDecorations = null;

        }

        private void lblMed_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblMed_MouseEnter(object sender, MouseEventArgs e)
        {
            lblMed.TextDecorations = TextDecorations.Underline;
        }

        private void lblMed_MouseLeave(object sender, MouseEventArgs e)
        {
            lblMed.TextDecorations = null;

        }

        private void lblInventSum_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblInventSum_MouseEnter(object sender, MouseEventArgs e)
        {
            lblInventSum.TextDecorations = TextDecorations.Underline;
        }

        private void lblInventSum_MouseLeave(object sender, MouseEventArgs e)
        {
            lblInventSum.TextDecorations = null;

        }

        private void lblTranStockIn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblTranStockIn_MouseEnter(object sender, MouseEventArgs e)
        {
            lblTranStockIn.TextDecorations = TextDecorations.Underline;
        }

        private void lblTranStockIn_MouseLeave(object sender, MouseEventArgs e)
        {
            lblTranStockIn.TextDecorations = null;

        }

        private void lblTranStockOut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lblTranStockOut.TextDecorations = TextDecorations.Underline;
        }

        private void lblTranStockOut_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void lblTranStockOut_MouseLeave(object sender, MouseEventArgs e)
        {
            lblTranStockOut.TextDecorations = null;
        }

        private void lblAdjustments_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblAdjustments_MouseEnter(object sender, MouseEventArgs e)
        {
            lblAdjustments.TextDecorations = TextDecorations.Underline;
        }

        private void lblAdjustments_MouseLeave(object sender, MouseEventArgs e)
        {
            lblAdjustments.TextDecorations = null;
        }

        private void lblReportStock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblReportStock_MouseEnter(object sender, MouseEventArgs e)
        {
            lblReportStock.TextDecorations = TextDecorations.Underline;
        }

        private void lblReportStock_MouseLeave(object sender, MouseEventArgs e)
        {
            lblReportStock.TextDecorations = null;

        }

        private void lblStockOut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblStockOut_MouseEnter(object sender, MouseEventArgs e)
        {
            lblStockOut.TextDecorations = TextDecorations.Underline;
        }

        private void lblStockOut_MouseLeave(object sender, MouseEventArgs e)
        {
            lblStockOut.TextDecorations = null;
        }

        private void lblOutstanding_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblOutstanding_MouseEnter(object sender, MouseEventArgs e)
        {
            lblOutstanding.TextDecorations = TextDecorations.Underline;
        }

        private void lblOutstanding_MouseLeave(object sender, MouseEventArgs e)
        {
            lblOutstanding.TextDecorations = null;
        }

        private void lblExpiring_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblExpiring_MouseEnter(object sender, MouseEventArgs e)
        {
            lblExpiring.TextDecorations = TextDecorations.Underline;
        }

        private void lblExpiring_MouseLeave(object sender, MouseEventArgs e)
        {
            lblExpiring.TextDecorations = null;
        }

        private void lblStaff_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblStaff_MouseEnter(object sender, MouseEventArgs e)
        {
            lblStaff.TextDecorations = TextDecorations.Underline;
        }

        private void lblStaff_MouseLeave(object sender, MouseEventArgs e)
        {
            lblStaff.TextDecorations = null;
        }

        private void lblList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblList_MouseEnter(object sender, MouseEventArgs e)
        {
            lblList.TextDecorations = TextDecorations.Underline;
        }

        private void lblList_MouseLeave(object sender, MouseEventArgs e)
        {
            lblList.TextDecorations = null;
        }

        private void lblUserMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblUserMain_MouseEnter(object sender, MouseEventArgs e)
        {
            lblUserMain.TextDecorations = TextDecorations.Underline;
        }

        private void lblUserMain_MouseLeave(object sender, MouseEventArgs e)
        {
            lblUserMain.TextDecorations = null;
        }

        private void lblRole_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void lblRole_MouseEnter(object sender, MouseEventArgs e)
        {
            lblRole.TextDecorations = TextDecorations.Underline;

        }

        private void lblRole_MouseLeave(object sender, MouseEventArgs e)
        {
            lblRole.TextDecorations = null;
        }

        private void lblEmployee_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblEmployee_MouseEnter(object sender, MouseEventArgs e)
        {
            lblEmployee.TextDecorations = TextDecorations.Underline;
        }

        private void lblEmployee_MouseLeave(object sender, MouseEventArgs e)
        {
            lblEmployee.TextDecorations = null;
        }

        private void lblDepartment_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lblDepartment_MouseEnter(object sender, MouseEventArgs e)
        {
            lblDepartment.TextDecorations = TextDecorations.Underline;
        }

        private void lblDepartment_MouseLeave(object sender, MouseEventArgs e)
        {
            lblDepartment.TextDecorations = null;
        }
    }
}

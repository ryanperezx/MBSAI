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
using System.Data.Common;
using System.Windows.Navigation;


namespace MBSAI
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        //Maintenance Management DONE
        DepartmentMaintenance dm = new DepartmentMaintenance();
        EmployeeMaintenance em = new EmployeeMaintenance();
        RoleMaintenance rm = new RoleMaintenance();
        UserMaintenance um = new UserMaintenance();
        //Reference Data DONE
        InventoryType it = new InventoryType();
        MedicalEquipment me = new MedicalEquipment();
        MedicalSupplies ms = new MedicalSupplies();
        Unit u = new Unit();
        Medical m = new Medical();
        //ReportManagement DONE
        ExpiringInvent ei = new ExpiringInvent();
        ListofAdjustments loa = new ListofAdjustments();
        OutstandingInvent oi = new OutstandingInvent();
        ReportsStockIN rsi = new ReportsStockIN();
        ReportsStockOut rso = new ReportsStockOut();
        StaffRequest sr = new StaffRequest();
        //Transaction Management
        Adjustments a = new Adjustments();
        InventorySummary ins = new InventorySummary();
        TransactStockIn tsi = new TransactStockIn();
        TransactStockOut tso = new TransactStockOut();

        public Main()
        {
            InitializeComponent();
            date.Content = DateTime.Now.ToString("D");
            stack.DataContext = new ExpanderListViewModel();

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
            Frame.Navigate(it);
        }

        private void lblInvent_MouseEnter(object sender, MouseEventArgs e)
        {
            lblInvent.TextDecorations = TextDecorations.Underline;
        }

        private void lblInvent_MouseLeave(object sender, MouseEventArgs e)
        {
            lblInvent.TextDecorations = null;
        }

        private void lblMedSup_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(ms);
        }

        private void lblMedSup_MouseEnter(object sender, MouseEventArgs e)
        {
            lblMedSup.TextDecorations = TextDecorations.Underline;
        }

        private void lblMedSup_MouseLeave(object sender, MouseEventArgs e)
        {
            lblMedSup.TextDecorations = null;

        }

        private void lblMedEqp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(me);
        }

        private void lblMedEqp_MouseEnter(object sender, MouseEventArgs e)
        {
            lblMedEqp.TextDecorations = TextDecorations.Underline;
        }

        private void lblMedEqp_MouseLeave(object sender, MouseEventArgs e)
        {
            lblMedEqp.TextDecorations = null;
        }


        private void lblMed_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(m);
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
            Frame.Navigate(ins);
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
            Frame.Navigate(tsi);
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
            Frame.Navigate(tso);
    
        }

        private void lblTranStockOut_MouseEnter(object sender, MouseEventArgs e)
        {
            lblTranStockOut.TextDecorations = TextDecorations.Underline;

        }

        private void lblTranStockOut_MouseLeave(object sender, MouseEventArgs e)
        {
            lblTranStockOut.TextDecorations = null;
        }

        private void lblAdjustments_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(a);
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
            Frame.Navigate(rsi);
        }

        private void lblReportStock_MouseEnter(object sender, MouseEventArgs e)
        {
            lblReportStockIn.TextDecorations = TextDecorations.Underline;
        }

        private void lblReportStock_MouseLeave(object sender, MouseEventArgs e)
        {
            lblReportStockIn.TextDecorations = null;

        }

        private void lblStockOut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(rso);
        }

        private void lblStockOut_MouseEnter(object sender, MouseEventArgs e)
        {
            lblReportStockOut.TextDecorations = TextDecorations.Underline;
        }

        private void lblStockOut_MouseLeave(object sender, MouseEventArgs e)
        {
            lblReportStockOut.TextDecorations = null;
        }

        private void lblOutstanding_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(oi);
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
            Frame.Navigate(ei);
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
            Frame.Navigate(sr);
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
            Frame.Navigate(loa);
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
            Frame.Navigate(um);
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
            Frame.Navigate(rm);
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
            Frame.Navigate(em);
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
            Frame.Navigate(dm);
        }

        private void lblDepartment_MouseEnter(object sender, MouseEventArgs e)
        {
            lblDepartment.TextDecorations = TextDecorations.Underline;
        }

        private void lblDepartment_MouseLeave(object sender, MouseEventArgs e)
        {
            lblDepartment.TextDecorations = null;
        }

        private void lblUnit_MouseEnter(object sender, MouseEventArgs e)
        {
            lblUnit.TextDecorations = TextDecorations.Underline;

        }

        private void lblUnit_MouseLeave(object sender, MouseEventArgs e)
        {
            lblUnit.TextDecorations = null;

        }

        private void lblUnit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(u);
        }

        private void Frame_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Forward)
            {
                e.Cancel = true;
            }
            if (e.NavigationMode == NavigationMode.Back)
            {
                e.Cancel = true;
            }
        }
    }
}

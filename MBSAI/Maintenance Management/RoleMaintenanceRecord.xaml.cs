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
using System.Collections.ObjectModel;


namespace MBSAI
{
    /// <summary>
    /// Interaction logic for RoleMaintenanceRecord.xaml
    /// </summary>
    public partial class RoleMaintenanceRecord : Page
    {
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<GridViewReferenceData> roles = new ObservableCollection<GridViewReferenceData>();
        int currentPageIndex = 0;
        int itemPerPage = 5;
        int totalPage = 0;
        public RoleMaintenanceRecord()
        {
            InitializeComponent();
            updateListView();
        }

        private void updateListView()
        {
            roles.Add(new GridViewReferenceData
            {
                Code = "PRV001",
                Desc = "Reference Data",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true
            });
            roles.Add(new GridViewReferenceData
            {
                Code = "PRV002",
                Desc = "Stock In",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = DateTime.Now.ToString("dd MMMM yyyy"),
                active = false
            });
            roles.Add(new GridViewReferenceData
            {
                Code = "PRV003",
                Desc = "Stock Out",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = DateTime.Now.ToString("dd MMMM yyyy"),
                active = false
            });
            roles.Add(new GridViewReferenceData
            {
                Code = "PRV004",
                Desc = "Stock Adjustment",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = DateTime.Now.ToString("dd MMMM yyyy"),
                active = false
            });
            roles.Add(new GridViewReferenceData
            {
                Code = "PRV005",
                Desc = "Maintenance Management",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true
            });
            roles.Add(new GridViewReferenceData
            {
                Code = "PRV006",
                Desc = "Reports Maintenance",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true
            });
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int itemcount = 6;
            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = roles;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvRoleDetails.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = roles.IndexOf((GridViewReferenceData)e.Item);

            if (index >= itemPerPage * currentPageIndex && index < itemPerPage * (currentPageIndex + 1))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
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

        private void btnPrevious_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Display previous page 
            if (currentPageIndex > 0)
            {
                currentPageIndex--;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }

        private void btnNext_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Display next page 
            if (currentPageIndex < totalPage - 1)
            {
                currentPageIndex++;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }

        private void btnLast_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Display the last page 
            if (currentPageIndex != totalPage - 1)
            {
                currentPageIndex = totalPage - 1;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }

        private void btnFirst_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Display the first page 
            if (currentPageIndex != 0)
            {
                currentPageIndex = 0;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }
    }
}

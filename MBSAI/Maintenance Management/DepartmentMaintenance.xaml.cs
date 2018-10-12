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
    /// Interaction logic for DepartmentMaintenance.xaml
    /// </summary>
    public partial class DepartmentMaintenance : Page
    {
        DepartmentMaintenanceRecord dmr = new DepartmentMaintenanceRecord();
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<GridViewReferenceData> departments = new ObservableCollection<GridViewReferenceData>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;
        public DepartmentMaintenance()
        {
            InitializeComponent();
            updateListView();

        }

        private void updateListView()
        {
            departments.Add(new GridViewReferenceData
            {
                Code = "DEP001",
                Desc = "12P Accounts Payable",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });

            departments.Add(new GridViewReferenceData
            {
                Code = "DEP002",
                Desc = "12C Accounting Support",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });

            departments.Add(new GridViewReferenceData
            {
                Code = "DEP003",
                Desc = "A2R (AR)Procurement",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });

            departments.Add(new GridViewReferenceData
            {
                Code = "DEP004",
                Desc = "T&E Travel and Expense",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });

            departments.Add(new GridViewReferenceData
            {
                Code = "DEP005",
                Desc = "Intercompany GL",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });

            departments.Add(new GridViewReferenceData
            {
                Code = "DEP006",
                Desc = "Fixed Asset",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });

            departments.Add(new GridViewReferenceData
            {
                Code = "DEP007",
                Desc = "Human Resources",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });

            departments.Add(new GridViewReferenceData
            {
                Code = "DEP008",
                Desc = "Administration",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });
        }
        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int itemcount = 8;


            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = departments;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvDepartMaintenance.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();


        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = departments.IndexOf((GridViewReferenceData)e.Item);

            if (index >= itemPerPage * currentPageIndex && index < itemPerPage * (currentPageIndex + 1))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void Add_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(dmr);
        }

        private void Reload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new DepartmentMaintenance());
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

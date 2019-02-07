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
    /// Interaction logic for UserMaintenance.xaml
    /// </summary>
    public partial class UserMaintenance : Page
    {
        UserMaintenanceDetails umd = new UserMaintenanceDetails();
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<GridViewUserEmployee> users = new ObservableCollection<GridViewUserEmployee>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;
        public UserMaintenance()
        {
            InitializeComponent();
            updateListView();
        }

        private void updateListView()
        {
            users.Add(new GridViewUserEmployee
            {
                Code = "USR001",
                Desc = "Joann Suriaga",
                Role = "IT Admin",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                enabled = true,
                locked = false
            });
            users.Add(new GridViewUserEmployee
            {
                Code = "USR002",
                Desc = "Marinette Salutan",
                Role = "Nurse 1",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                enabled = true,
                locked = false
            });
            users.Add(new GridViewUserEmployee
            {
                Code = "USR003",
                Desc = "Sharamai Ramirez",
                Role = "Accountant",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                enabled = true,
                locked = false
            });
            users.Add(new GridViewUserEmployee
            {
                Code = "USR004",
                Desc = "Sharon DeLeon",
                Role = "Bookeeper",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                enabled = true,
                locked = false
            });
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int itemcount = 4;


            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = users;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvUserMaintenance.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = users.IndexOf((GridViewUserEmployee)e.Item);

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
            this.NavigationService.Navigate(umd);
        }

        private void Reload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Refresh();
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

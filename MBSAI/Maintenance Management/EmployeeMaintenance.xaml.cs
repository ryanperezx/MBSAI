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
using System.Collections.ObjectModel;

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
            updateListView();
        }

        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<GridViewEmployeeMaintenance> employees = new ObservableCollection<GridViewEmployeeMaintenance>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;

        private void updateListView()
        {
            employees.Add(new GridViewEmployeeMaintenance
            {
                Code = "EMP001",
                empName = "Tankiang Angelita L.",
                department = "Information Technology",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true
            });

            employees.Add(new GridViewEmployeeMaintenance
            {
                Code = "EMP002",
                empName = "Balce Rizaldy E.",
                department = "Clinic",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true
            });

            employees.Add(new GridViewEmployeeMaintenance
            {
                Code = "EMP003",
                empName = "Salazar Djonivic B.",
                department = "Clinic",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true
            });

            employees.Add(new GridViewEmployeeMaintenance
            {
                Code = "EMP004",
                empName = "Currimo Angelito C.",
                department = "Clinic",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true
            });
        }
        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int itemcount = 4;


            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = employees;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvEmpMaintenance.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = employees.IndexOf((GridViewEmployeeMaintenance)e.Item);

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
            this.NavigationService.Navigate(new EmployeeMaintenanceRecord());
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

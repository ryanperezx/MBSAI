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
    /// Interaction logic for MedicalEquipment.xaml
    /// </summary>
    public partial class MedicalEquipment : Page
    {
        MedicalEquipmentRecord mer = new MedicalEquipmentRecord();
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<GridViewReferenceData> equipments = new ObservableCollection<GridViewReferenceData>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;
        public MedicalEquipment()
        {
            InitializeComponent();
            updateListView();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int itemcount = 4;

            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = equipments;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvMedEqp.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        private void updateListView()
        {
            equipments.Add(new GridViewReferenceData
            {
                Code = "MEQ001",
                Desc = "Nebulizer",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });
            equipments.Add(new GridViewReferenceData
            {
                Code = "MEQ002",
                Desc = "Infusion Pump",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });
            equipments.Add(new GridViewReferenceData
            {
                Code = "MEQ003",
                Desc = "Pulse Oximeters",
                startDate = DateTime.Now.ToString("dd MMMM yyyy"),
                endDate = "--",
                active = true,
                used = true
            });
            equipments.Add(new GridViewReferenceData
            {
                Code = "MEQ004",
                Desc = "Stretchers",
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

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = equipments.IndexOf((GridViewReferenceData)e.Item);

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
            this.NavigationService.Navigate(new MedicalEquipmentRecord());
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

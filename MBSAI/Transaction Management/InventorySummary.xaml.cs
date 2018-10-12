using System;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;


namespace MBSAI
{
    /// <summary>
    /// Interaction logic for InventorySummary.xaml
    /// </summary>
    public partial class InventorySummary : Page
    {
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<ListViewInventorySummary> summary = new ObservableCollection<ListViewInventorySummary>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;
        public InventorySummary()
        {
            InitializeComponent();
            updateListView();
            date.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void updateListView()
        {
            summary.Add(new ListViewInventorySummary {
                inventType = "Medical Supplies",
                stockID = "MES001",
                desc = "Magnifying Glass",
                qty = 10,
                unit = "Piece"
            });
            summary.Add(new ListViewInventorySummary
            {
                inventType = "Medical Equipment",
                stockID = "MEQ001",
                desc = "Nebulizer",
                qty = 1,
                unit = "Piece"
            });
            summary.Add(new ListViewInventorySummary
            {
                inventType = "Medicines",
                stockID = "MED001",
                desc = "Biogesic",
                qty = 90,
                unit = "Piece"
            });
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int itemcount = 3;

            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = summary;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvInvent.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = summary.IndexOf((ListViewInventorySummary)e.Item);

            if (index >= itemPerPage * currentPageIndex && index < itemPerPage * (currentPageIndex + 1))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
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

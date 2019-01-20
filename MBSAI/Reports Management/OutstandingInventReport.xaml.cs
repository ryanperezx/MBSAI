using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlServerCe;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
namespace MBSAI
{
    /// <summary>
    /// Interaction logic for OutstandingInventReport.xaml
    /// </summary>
    public partial class OutstandingInventReport : Page
    {
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<ListViewOutstandingInventReport> outstandings = new ObservableCollection<ListViewOutstandingInventReport>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;
        int itemcount;
        int i = 1;
        string dateToday;
        public OutstandingInventReport(string date)
        {
            InitializeComponent();
            lblDate.Content = date;
            dateToday = date;
            updateListView();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = outstandings;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvOutstandingInvent.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = outstandings.IndexOf((ListViewOutstandingInventReport)e.Item);

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

        private void updateListView()
        {
            /*
            using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblReportStockIn where date < '" + dateToday + "'", conn))
            {
                lvOutstandingInvent.Items.Clear();
                using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                {
                    while (reader.Read())
                    {
                        //2
                        int inventTypeIndex = reader.GetOrdinal("inventType");
                        string inventType = Convert.ToString(reader.GetValue(inventTypeIndex));
                        //3
                        int codeIndex = reader.GetOrdinal("code");
                        string code = Convert.ToString(reader.GetValue(codeIndex));
                        //4
                        int descIndex = reader.GetOrdinal("desc");
                        string desc = Convert.ToString(reader.GetValue(descIndex));
                        //5
                        int genNameIndex = reader.GetOrdinal("genName");
                        string genName;
                        if(reader.GetValue(genNameIndex) == DBNull.Value)
                        {
                            genName = "--";
                        }
                        else
                        {
                            genName = Convert.ToString(reader.GetValue(genNameIndex));
                        }
                        //7
                        int qtyIndex = reader.GetOrdinal("qty");
                        int qty = Convert.ToInt32(reader.GetValue(qtyIndex));
                        //8
                        int unitIndex = reader.GetOrdinal("unit");
                        string unit = Convert.ToString(reader.GetValue(unitIndex));

                        outstandings.Add(new ListViewOutstandingInventReport
                        {
                            i = i,
                            inventType = inventType,
                            code = code,
                            desc = desc,
                            genName = genName,
                            qty = qty,
                            unit = unit
                        });
                        i++;
                        itemcount++;
                    }
                }
            }
            */
        }

    }
}

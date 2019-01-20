using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlServerCe;
using System.Collections.ObjectModel;

namespace MBSAI
{
    /// <summary>
    /// Interaction logic for ListofAdjustmentReport.xaml
    /// </summary>
    public partial class ListofAdjustmentReport : Page
    {
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<ListViewAdjustments> adjusts = new ObservableCollection<ListViewAdjustments>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;
        int itemcount;
        int i = 1;
        DateTime myDate;
        string from, to, inventType;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = adjusts;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvAdjustment.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        public ListofAdjustmentReport(string f, string it, string t = "")
        {
            InitializeComponent();
            inventType = it;
            if (string.IsNullOrWhiteSpace(t))
            {
                lblDate.Content = f;
                from = f;
                to = f;
            }
            else
            {
                lblDate.Content = f + " - " + t;
                from = f;
                to = t;
            }
            updateListView();
        }

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = adjusts.IndexOf((ListViewAdjustments)e.Item);

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
            string sql;
            if (inventType == "ALL")
            {
                if (string.IsNullOrEmpty(to))
                {
                    sql = "SELECT * from tblAdjustments where adjustDate > '" + from + "'";
                }
                else
                {
                    sql = "SELECT * from tblAdjustments where adjustDate between '" + from + "' and '" + to + "'";
                }
                /*
                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    lvAdjustment.Items.Clear();
                    using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                    {
                        while (reader.Read())
                        {
                            //1
                            int adjustDateIndex = reader.GetOrdinal("adjustDate");
                            myDate = Convert.ToDateTime(reader.GetValue(adjustDateIndex));
                            string adjustDate = myDate.ToString("dd MMMM yyyy");
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
                            int byIndex = reader.GetOrdinal("by");
                            string by = Convert.ToString(reader.GetValue(byIndex));
                            //6
                            int deptIndex = reader.GetOrdinal("dept");
                            string dept = Convert.ToString(reader.GetValue(deptIndex));
                            //7
                            int qtyIndex = reader.GetOrdinal("qty");
                            int qty = Convert.ToInt32(reader.GetValue(qtyIndex));
                            //8
                            int unitIndex = reader.GetOrdinal("unit");
                            string unit = Convert.ToString(reader.GetValue(unitIndex));
                            //9
                            int remarksIndex = reader.GetOrdinal("remarks");
                            string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                            adjusts.Add(new ListViewAdjustments
                            {
                                i = i,
                                adjustDate = adjustDate,
                                inventType = inventType,
                                code = code,
                                desc = desc,
                                by = by,
                                dept = dept,
                                qty = qty,
                                unit = unit,
                                remarks = remarks
                            });
                            i++;
                            itemcount++;
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(to))
                {
                    sql = "SELECT * from tblAdjustments where adjustDate > '" + from + "' and inventType = '" + inventType + "'";
                }
                else
                {
                    sql = "SELECT * from tblAdjustments where adjustDate between '" + from + "' and '" + to + "' and inventType = '" + inventType + "'";
                }
                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    lvAdjustment.Items.Clear();
                    using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                    {
                        while (reader.Read())
                        {
                            //1
                            int adjustDateIndex = reader.GetOrdinal("adjustDate");
                            myDate = Convert.ToDateTime(reader.GetValue(adjustDateIndex));
                            string adjustDate = myDate.ToString("dd MMMM yyyy");
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
                            int byIndex = reader.GetOrdinal("by");
                            string by = Convert.ToString(reader.GetValue(byIndex));
                            //6
                            int deptIndex = reader.GetOrdinal("dept");
                            string dept = Convert.ToString(reader.GetValue(deptIndex));
                            //7
                            int qtyIndex = reader.GetOrdinal("qty");
                            int qty = Convert.ToInt32(reader.GetValue(qtyIndex));
                            //8
                            int unitIndex = reader.GetOrdinal("unit");
                            string unit = Convert.ToString(reader.GetValue(unitIndex));
                            //9
                            int remarksIndex = reader.GetOrdinal("remarks");
                            string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                            adjusts.Add(new ListViewAdjustments
                            {
                                i = i,
                                adjustDate = adjustDate,
                                inventType = inventType,
                                code = code,
                                desc = desc,
                                by = by,
                                dept = dept,
                                qty = qty,
                                unit = unit,
                                remarks = remarks
                            });
                            itemcount++;
                            i++;
                        }
                    }
                }
                */
            }
        }
    }
}

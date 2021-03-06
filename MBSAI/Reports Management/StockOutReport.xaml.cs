﻿using System;
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
    /// Interaction logic for StockOutReport.xaml
    /// </summary>
    public partial class StockOutReport : Page
    {
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<ListViewStockOutReport> reports = new ObservableCollection<ListViewStockOutReport>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;
        int itemcount;
        int i = 1;
        string to, from, inventType;

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = reports;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvStockOut.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = reports.IndexOf((ListViewStockOutReport)e.Item);

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

        public StockOutReport(string f, string it, string t = "")
        {
            InitializeComponent();
            lblInventType.Content = it;
            inventType = it;
            if (string.IsNullOrWhiteSpace(t))
            {
                lblDate.Content = f;
                to = f;
                from = f;
            }
            else
            {
                lblDate.Content = f + " - " + t;
                from = f;
                to = t;
            }
            updateListView();
        }
        
        private void updateListView()
        {
            /*
            string sql;
            if (inventType == "ALL")
            {
                if (string.IsNullOrEmpty(to))
                {
                    sql = "SELECT * from tblReportStockOut where date > '" + from + "'";
                }
                else
                {
                    sql = "SELECT * from tblReportStockOut where date between '" + from + "' and '" + to + "'";
                }
                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    lvStockOut.Items.Clear();
                    using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                    {
                        while (reader.Read())
                        {
                            //1
                            int dateIndex = reader.GetOrdinal("date");
                            DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                            string date = myDate.ToString("dd MMMM yyyy");
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
                            int releasedToIndex = reader.GetOrdinal("releasedTo");
                            string releasedTo = Convert.ToString(reader.GetValue(releasedToIndex));
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
                            int returnDateIndex = reader.GetOrdinal("returnDate");
                            string returnDate;
                            if (reader.GetValue(returnDateIndex) == DBNull.Value)
                            {
                                returnDate = "--";
                            }
                            else
                            {
                                myDate = Convert.ToDateTime(reader.GetValue(returnDateIndex));
                                returnDate = myDate.ToString("dd MMMM yyyy");
                            }
                            //11
                            int remarksIndex = reader.GetOrdinal("remarks");
                            string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                            reports.Add(new ListViewStockOutReport
                            {
                                i = i,
                                date = date,
                                inventType = inventType,
                                code = code,
                                desc = desc,
                                releasedTo = releasedTo,
                                dept = dept,
                                qty = qty,
                                unit = unit,
                                returnDate = returnDate,
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
                    sql = "SELECT * from tblReportStockOut where date > '" + from + "' and inventType ='" + inventType + "'";
                }
                else
                {
                    sql = "SELECT * from tblReportStockOut where date between '" + from + "' and '" + to + "' and inventType='" + inventType + "'";
                }
                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    lvStockOut.Items.Clear();
                    using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                    {
                        while (reader.Read())
                        {
                            //1
                            int dateIndex = reader.GetOrdinal("date");
                            DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                            string date = myDate.ToString("dd MMMM yyyy");
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
                            int releasedToIndex = reader.GetOrdinal("releasedTo");
                            string releasedTo = Convert.ToString(reader.GetValue(releasedToIndex));
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
                            int returnDateIndex = reader.GetOrdinal("returnDate");
                            string returnDate;
                            if (reader.GetValue(returnDateIndex) == DBNull.Value)
                            {
                                returnDate = "--";
                            }
                            else
                            {
                                myDate = Convert.ToDateTime(reader.GetValue(returnDateIndex));
                                returnDate = myDate.ToString("dd MMMM yyyy");
                            }
                            //11
                            int remarksIndex = reader.GetOrdinal("remarks");
                            string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                            reports.Add(new ListViewStockOutReport
                            {
                                i = i,
                                date = date,
                                inventType = inventType,
                                code = code,
                                desc = desc,
                                releasedTo = releasedTo,
                                dept = dept,
                                qty = qty,
                                unit = unit,
                                returnDate = returnDate,
                                remarks = remarks
                            });
                            i++;
                            itemcount++;
                        }
                    }
                }
                
            }
            */
        }
    }
}

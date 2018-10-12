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
    /// Interaction logic for StockInReport.xaml
    /// </summary>
    public partial class StockInReport : Page
    {

        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<ListViewStockInReport> reports = new ObservableCollection<ListViewStockInReport>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;
        int itemcount;
        int i = 1;
        string to, from, inventType;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = reports;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvStockIn.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = reports.IndexOf((ListViewStockInReport)e.Item);

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

        public StockInReport(string f, string it, string t = "")
        {
            InitializeComponent();
            lblInventType.Content = it;
            inventType = it;
            if(string.IsNullOrWhiteSpace(t))
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
            SqlCeConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string sql;
            if (inventType == "ALL")
            {
                if (string.IsNullOrEmpty(to))
                {
                    sql = "SELECT * from tblReportStockIn where date > '" + from + "'";
                }
                else
                {
                    sql = "SELECT * from tblReportStockIn where date between '" + from + "' and '" + to + "'";
                }
                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    lvStockIn.Items.Clear();
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
                            int genNameIndex = reader.GetOrdinal("genName");
                            string genName = Convert.ToString(reader.GetValue(genNameIndex));
                            //6
                            int qtyIndex = reader.GetOrdinal("qty");
                            int qty = Convert.ToInt32(reader.GetValue(qtyIndex));
                            //7
                            int unitIndex = reader.GetOrdinal("unit");
                            string unit = Convert.ToString(reader.GetValue(unitIndex));
                            //8
                            int ppUnitIndex = reader.GetOrdinal("priceperUnit");
                            double ppUnitDouble = Convert.ToDouble(reader.GetValue(ppUnitIndex));
                            string ppUnit = ppUnitDouble.ToString("F");
                            //9
                            int datePurchaseIndex = reader.GetOrdinal("datePurchase");
                            myDate = Convert.ToDateTime(reader.GetValue(datePurchaseIndex));
                            string datePurchase = myDate.ToString("dd MMMM yyyy");
                            //10
                            int dateExpiryIndex = reader.GetOrdinal("dateExpiry");
                            string dateExpiry;
                            if (reader.GetValue(dateExpiryIndex) == DBNull.Value)
                            {
                                dateExpiry = "--";

                            }
                            else
                            {
                                DateTime dateExpiryDate = Convert.ToDateTime(reader.GetValue(dateExpiryIndex));
                                dateExpiry = dateExpiryDate.ToString("dd MMMM yyyy");
                            }
                            //11
                            int manufIndex = reader.GetOrdinal("manuf");
                            string manuf = Convert.ToString(reader.GetValue(manufIndex));
                            //12
                            int vendorIndex = reader.GetOrdinal("vendor");
                            string vendor = Convert.ToString(reader.GetValue(vendorIndex));
                            //13
                            int branchIndex = reader.GetOrdinal("branch");
                            string branch = Convert.ToString(reader.GetValue(branchIndex));
                            reports.Add(new ListViewStockInReport
                            {
                                i = i,
                                date = date,
                                inventType = inventType,
                                code = code,
                                desc = desc,
                                genName = genName,
                                qty = qty,
                                unit = unit,
                                priceperUnit = ppUnit,
                                datePurchase = datePurchase,
                                dateExpiry = dateExpiry,
                                manuf = manuf,
                                vendor = vendor,
                                branch = branch
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
                    sql = "SELECT * from tblReportStockIn where date > '" + from + "' and inventType ='" + inventType + "'";
                }
                else
                {
                    sql = "SELECT * from tblReportStockIn where date between '" + from + "' and '" + to + "' and inventType='" + inventType + "'";
                }
                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    lvStockIn.Items.Clear();
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
                            int genNameIndex = reader.GetOrdinal("genName");
                            string genName = Convert.ToString(reader.GetValue(genNameIndex));
                            //6
                            int qtyIndex = reader.GetOrdinal("qty");
                            int qty = Convert.ToInt32(reader.GetValue(qtyIndex));
                            //7
                            int unitIndex = reader.GetOrdinal("unit");
                            string unit = Convert.ToString(reader.GetValue(unitIndex));
                            //8
                            int ppUnitIndex = reader.GetOrdinal("priceperUnit");
                            double ppUnitDouble = Convert.ToDouble(reader.GetValue(ppUnitIndex));
                            string ppUnit = ppUnitDouble.ToString("F");
                            //9
                            int datePurchaseIndex = reader.GetOrdinal("datePurchase");
                            myDate = Convert.ToDateTime(reader.GetValue(datePurchaseIndex));
                            string datePurchase = myDate.ToString("dd MMMM yyyy");
                            //10
                            int dateExpiryIndex = reader.GetOrdinal("dateExpiry");
                            string dateExpiry;
                            if (reader.GetValue(dateExpiryIndex) == DBNull.Value)
                            {
                                dateExpiry = "--";

                            }
                            else
                            {
                                DateTime dateExpiryDate = Convert.ToDateTime(reader.GetValue(dateExpiryIndex));
                                dateExpiry = dateExpiryDate.ToString("dd MMMM yyyy");
                            }
                            //11
                            int manufIndex = reader.GetOrdinal("manuf");
                            string manuf = Convert.ToString(reader.GetValue(manufIndex));
                            //12
                            int vendorIndex = reader.GetOrdinal("vendor");
                            string vendor = Convert.ToString(reader.GetValue(vendorIndex));
                            //13
                            int branchIndex = reader.GetOrdinal("branch");
                            string branch = Convert.ToString(reader.GetValue(branchIndex));
                            reports.Add(new ListViewStockInReport
                            {
                                i = i,
                                date = date,
                                inventType = inventType,
                                code = code,
                                desc = desc,
                                genName = genName,
                                qty = qty,
                                unit = unit,
                                priceperUnit = ppUnit,
                                datePurchase = datePurchase,
                                dateExpiry = dateExpiry,
                                manuf = manuf,
                                vendor = vendor,
                                branch = branch
                            });
                            i++;
                            itemcount++;
                        }
                    }
                }
            }
        }
    }
}

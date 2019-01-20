using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlServerCe;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
namespace MBSAI
{
    /// <summary>
    /// Interaction logic for StaffRequestReport.xaml
    /// </summary>
    public partial class StaffRequestReport : Page
    {
        private DateTime myDate;
        string from, to, inventoryType, department;
        int i = 1;
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<ListViewStockOutReport> staffs = new ObservableCollection<ListViewStockOutReport>();
        int currentPageIndex = 0;
        int itemPerPage = 10;
        int totalPage = 0;
        int itemCount;


        public StaffRequestReport(string f, string dpt, string it, string t = "")
        {
            InitializeComponent();
            lblDeparment.Content = dpt;
            inventoryType = it;
            department = dpt;
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int itemcount = 10;

            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = staffs;

            view.Filter += new FilterEventHandler(view_Filter);
            this.lvStaffRequest.DataContext = view;
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = staffs.IndexOf((ListViewStockOutReport)e.Item);

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
            lvStaffRequest.Items.Clear();
            if (inventoryType == "ALL" && department == "ALL")
            {
                using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblStaffRequest where date between '" + from + "' and '" + to + "'", conn))
                {
                    using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                    {
                        while (reader.Read())
                        {
                            //1
                            int dateIndex = reader.GetOrdinal("date");
                            myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
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
                            staffs.Add(new ListViewStockOutReport
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
                            itemCount++;
                        }
                    }
                }
            }
            else if (inventoryType == "ALL")
            {
                using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblStaffRequest where date between '" + from + "' and '" + to + "' and dept ='" + department + "'", conn))
                {
                    using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                    {
                        while (reader.Read())
                        {
                            //1
                            int dateIndex = reader.GetOrdinal("date");
                            myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
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
                            staffs.Add(new ListViewStockOutReport
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
                            itemCount++;

                        }
                    }
                }
            }
            else if(department == "ALL")
            {
                using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblStaffRequest where date between '" + from + "' and '" + to + "' and inventType ='" + inventoryType + "'", conn))
                {
                    using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                    {
                        while (reader.Read())
                        {
                            //1
                            int dateIndex = reader.GetOrdinal("date");
                            myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
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
                            staffs.Add(new ListViewStockOutReport
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
                            itemCount++;

                        }
                    }
                }
            }
            else
            {
                using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblStaffRequest where date between '" + from + "' and '" + to + "' and dept ='" + department + "' and inventType='" + inventoryType + "'", conn))
                {
                    lvStaffRequest.Items.Clear();
                    using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                    {
                        while (reader.Read())
                        {
                            //1
                            int dateIndex = reader.GetOrdinal("date");
                            myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
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
                            staffs.Add(new ListViewStockOutReport
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
                            itemCount++;
                        }
                    }
                }
            }
            */
        }
    }
}

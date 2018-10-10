using System;
using System.Windows.Controls;
using System.Data.SqlServerCe;

namespace MBSAI
{
    /// <summary>
    /// Interaction logic for StockOutReport.xaml
    /// </summary>
    public partial class StockOutReport : Page
    {
        int i = 1;

        public StockOutReport(string f, string it, string t = "")
        {
            InitializeComponent();
            lblInventType.Content = it;
            if (string.IsNullOrWhiteSpace(t))
            {
                lblDate.Content = f;
            }
            else
            {
                lblDate.Content = f + " - " + t;
            }
            updateListView();
        }
        
        private void updateListView()
        {
            SqlCeConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblReportStockOut", conn))
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
                        lvStockOut.Items.Add(new ListViewStockOutReport
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
                    }
                }
            }
        }
    }
}

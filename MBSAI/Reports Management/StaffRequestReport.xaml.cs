using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlServerCe;
namespace MBSAI
{
    /// <summary>
    /// Interaction logic for StaffRequestReport.xaml
    /// </summary>
    public partial class StaffRequestReport : Page
    {
        public string inventoryType;
        public DateTime date, myDate;
        int i = 1;

        public StaffRequestReport(string f, string dpt, string it, string t = "")
        {
            InitializeComponent();
            lblDeparment.Content = dpt;
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
            using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblStaffRequest", conn))
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
                        lvStaffRequest.Items.Add(new ListViewStockOutReport
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

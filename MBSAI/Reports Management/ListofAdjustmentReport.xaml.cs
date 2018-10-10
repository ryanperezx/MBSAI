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
    /// Interaction logic for ListofAdjustmentReport.xaml
    /// </summary>
    public partial class ListofAdjustmentReport : Page
    {
        int i = 1;
        DateTime myDate;
        public ListofAdjustmentReport(string f, string it, string t = "")
        {
            InitializeComponent();
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
            using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblAdjustments", conn))
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
                        lvAdjustment.Items.Add(new ListViewAdjustments
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
                    }
                }
            }
        }
    }
}

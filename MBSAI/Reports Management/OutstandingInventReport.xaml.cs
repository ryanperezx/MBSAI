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
    /// Interaction logic for OutstandingInventReport.xaml
    /// </summary>
    public partial class OutstandingInventReport : Page
    {
        int i = 1;
        public OutstandingInventReport(string date)
        {
            InitializeComponent();
            lblDate.Content = date;
            updateListView();
        }

        private void updateListView()
        {
            SqlCeConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblOutstandingInvent", conn))
            {
                lvOutstandingInvent.Items.Clear();
                using (SqlCeDataReader reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
                {
                    while (reader.Read())
                    {
                        //2
                        int inventTypeIndex = reader.GetOrdinal("inventoryType");
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

                        lvOutstandingInvent.Items.Add(new ListViewOutstandingInventReport
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
                    }
                }
            }
        }
    }
}

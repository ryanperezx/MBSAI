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
    /// Interaction logic for ExpiringInventoryReport.xaml
    /// </summary>
    public partial class ExpiringInventoryReport : Page
    {
        private DateTime myDate;
        int i = 1;

        public ExpiringInventoryReport(string f, string it, string t = "")
        {
            InitializeComponent();
            lblInventoryType.Content = it;
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
            using (SqlCeCommand cmd = new SqlCeCommand("SELECT * from tblExpiringInventory", conn))
            {
                lvExpiringInvent.Items.Clear();
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
                        lvExpiringInvent.Items.Add(new ListViewStockInReport
                        {
                            i = i,
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
                    }
                }
            }
        }
    }
}

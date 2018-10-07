using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MBSAI
{
    /// <summary>
    /// Interaction logic for InventorySummary.xaml
    /// </summary>
    public partial class InventorySummary : Page
    {
        public InventorySummary()
        {
            InitializeComponent();
            ListViewInventorySummary item1 = new ListViewInventorySummary();
            item1.inventType = "Medical Supplies";
            item1.stockID = "MES001";
            item1.desc = "Magnifying Glass";
            item1.unit = "Piece";

            lvInvent.Items.Add(item1);

            ListViewInventorySummary item2 = new ListViewInventorySummary();
            item2.inventType = "Medical Equipment";
            item2.stockID = "MEQ001";
            item2.desc = "Nebulizer";
            item2.unit = "Piece";

            lvInvent.Items.Add(item2);
        }
    }
}

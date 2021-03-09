using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend;

namespace Groceries_App
{
    public partial class AddLooseItems : Form
    {
        List<GroceryItem> basicItems;
        public AddLooseItems()
        {
            InitializeComponent();
        }

        private void AddLooseItems_Load(object sender, EventArgs e)
        {
            basicItems = SQL.GetBasicItems();
            ((ListBox)clbBasicItems).DataSource = basicItems;
            ((ListBox)clbBasicItems).DisplayMember = "Name";

            //clbBasicItems.Items.AddRange(SQL.GetBasicItems().ToArray());

            dgwExtrasCbCategory.Items.Add("Vælg kategori");
            dgwExtrasCbCategory.Items.AddRange(Backend.SQL.GetGroceryCategoryOptions().ToArray());

        }

        private void dgwExtras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach(GroceryItem item in clbBasicItems.CheckedItems)
            {
                shopList.AddToLooseItems(item);
            }
            
            foreach (DataGridViewRow row in dgwExtras.Rows)
            {
                string itemName = Convert.ToString(row.Cells[2].Value);
                string category = Convert.ToString(row.Cells[3].Value);

                if (itemName != "")
                {
                    Backend.GroceryItem groceryItem = new Backend.GroceryItem(itemName);
                    groceryItem.Quantity = Convert.ToSingle(row.Cells[0].Value);
                    groceryItem.Unit = Convert.ToString(row.Cells[1].Value);
                    groceryItem.Category = category;
                    shopList.AddToLooseItems(groceryItem);
                }
            }
            
            this.Close();
            this.Dispose();
        }

        private void btnAnnull_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnAddBasicItems_Click(object sender, EventArgs e)
        {

        }
    }
}

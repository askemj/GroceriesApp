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
    public partial class AddRecipeToShoppingList : Form
    {
        Recipe recipe;
        public AddRecipeToShoppingList(Recipe _recipe)
        {
            InitializeComponent();
            recipe = _recipe;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddRecipeToShoppingList_Load(object sender, EventArgs e)
        {
            this.dgwIngredients.CellValueChanged -= new DataGridViewCellEventHandler( dgwIngredients_CellValueChanged);
            this.dgwTwists.CellValueChanged -= new DataGridViewCellEventHandler(dgwTwists_CellValueChanged);

            FillGroceryItems(dgwIngredients, recipe.Ingredients);
            FillGroceryItems(dgwTwists, recipe.Twists);

            dgwExtrasCbCategory.Items.Add("Vælg kategori");
            dgwExtrasCbCategory.Items.AddRange(Backend.SQL.GetGroceryCategoryOptions().ToArray());

            this.dgwIngredients.CellValueChanged += new DataGridViewCellEventHandler(dgwIngredients_CellValueChanged);
            this.dgwTwists.CellValueChanged += new DataGridViewCellEventHandler(dgwTwists_CellValueChanged);

            Console.WriteLine("Finished loading AddRecipeToShoppingList form");
        }

        private void FillGroceryItems(DataGridView dgw, List<GroceryItem> groceryItemList)
        {
            foreach (GroceryItem item in groceryItemList)
            {
                int rowID = dgw.Rows.Add();
                DataGridViewRow row = dgw.Rows[rowID];

                row.Cells[0].Value = item.Quantity;
                row.Cells[1].Value = item.Unit;
                row.Cells[2].Value = item.Name;
                if (dgw == dgwIngredients && item.BasicItem != true)
                {
                    row.Cells[3].Value = true;
                }
                else
                {
                    row.Cells[3].Value = false;
                }
            }
        }

        private void dgwIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            PopUnselectedGroceryItems(dgwIngredients, recipe.Ingredients);
            PopUnselectedGroceryItems(dgwTwists, recipe.Twists);

            // loose items 
            foreach (DataGridViewRow row in dgwExtras.Rows)
            {
                string itemName = Convert.ToString(row.Cells[2].Value);
                string category = Convert.ToString(row.Cells[3].Value);

                if (itemName != "")
                {
                    Backend.GroceryItem groceryItem = new Backend.GroceryItem(itemName);
                    groceryItem.Quantity = Convert.ToSingle(row.Cells[0].Value);
                    groceryItem.Unit = row.Cells[1].Value.ToString();
                    groceryItem.Category = category;
                    recipe.Twists.Add(groceryItem);
                }
            }

            shopList.AddRecipe(recipe);

            this.Close();
            this.Dispose();
        }

        private void PopUnselectedGroceryItems(DataGridView dgw, List<GroceryItem> groceryItems)
        {
            foreach (DataGridViewRow row in dgw.Rows)
            {
                    DataGridViewCheckBoxCell include = row.Cells[3] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(include.Value) == false)
                    {
                        var unselectedItem = groceryItems.Find(item => item.Name == row.Cells[2].Value.ToString() );
                        groceryItems.Remove( unselectedItem );
                    }
            }
        }

        private void dgwIngredients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgwIngredients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    float quantity = Convert.ToSingle(dgwIngredients.Rows[e.RowIndex].Cells[0].Value);
                    string name = dgwIngredients.Rows[e.RowIndex].Cells[2].Value.ToString();
                    var updatedItem = recipe.Ingredients.Find(item => item.Name == name);
                    updatedItem.Quantity = quantity;
                }
            }
        }

        private void dgwTwists_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgwTwists.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    float quantity = Convert.ToSingle(dgwTwists.Rows[e.RowIndex].Cells[0].Value);
                    string name = dgwTwists.Rows[e.RowIndex].Cells[2].Value.ToString();
                    var updatedItem = recipe.Twists.Find(item => item.Name == name);
                    updatedItem.Quantity = quantity;
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend;

namespace Groceries_App
{
    public partial class AddEditRecipe : Form
    {
        private string[] groceryItemCategories = Backend.SQL.GetGroceryCategoryOptions().ToArray();
        private Backend.Recipe newRecipe;

        public AddEditRecipe(Backend.Recipe recipe)
        {
            InitializeComponent();
            newRecipe = recipe;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbPreparationTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            if (ValidateFormInput())
            {
                newRecipe.Name = tbRecipeTitle.Text;
                newRecipe.PreparationTime = Convert.ToInt32(cbPreparationTime.Text);
                newRecipe.TotalTime = Convert.ToInt32(cbTotalTime.Text);
                newRecipe.NumberOfServings = Convert.ToInt32(tbNumberOfServings.Text);
                newRecipe.RecipeType = cbType.Text;
                newRecipe.Notes = rtbNotes.Text;

                //if (newRecipe.ID != 0)
                //{
                //    newRecipe.Ingredients.Clear();
                //    newRecipe.Twists.Clear();
                //    newRecipe.UsesLeftovers.Clear();
                //    newRecipe.ProducesLeftovers.Clear();
                //}

                newRecipe.Ingredients = GetGroceryItems(IngredientsDgw); //.AddRange(GetGroceryItems(IngredientsDgw));
                newRecipe.Twists = GetGroceryItems(TwistsDgw);

                newRecipe.UsesLeftovers = GetLeftovers(dgwUsesLeftovers);
                newRecipe.ProducesLeftovers = GetLeftovers(dgwProducesLeftovers);

                if (newRecipe.ID != 0)
                {
                    updateOutdatedDatabaseEntries(newRecipe);
                }

                Backend.SQL.UpdateRecipeDatabase(newRecipe);
                this.Close();
                this.Dispose();
            }
            else
            {
                //rtbHUD.Text = "Der mangler informationer til opskriften";
            }

        }

        private bool ValidateFormInput()
        {
            rtbHUD.Text = "";
            bool inputOK = new bool();

            bool recipeNameIsSet = !string.IsNullOrEmpty(newRecipe.Name);

            bool dropDownsAreSet = true;
            if (cbPreparationTime.SelectedItem == null || cbTotalTime.SelectedItem == null || cbType.SelectedItem == null)
            {
                dropDownsAreSet = false;
            }
            bool noServingsIsSet = !string.IsNullOrEmpty(tbNumberOfServings.Text);
            bool recipeGroceryItemsOK = true;
            
            foreach (DataGridViewRow row in IngredientsDgw.Rows)
            {
                if (Convert.ToString(row.Cells[3].Value) == "Vælg Kategori")
                {
                    recipeGroceryItemsOK = false;
                }
                if (Convert.ToString(row.Cells[0].Value).Contains("."))
                {
                    recipeGroceryItemsOK = false;
                }

            }
            foreach (DataGridViewRow row in TwistsDgw.Rows)
            {
                if (Convert.ToString(row.Cells[3].Value) == "Vælg Kategori")
                {
                    recipeGroceryItemsOK = false;
                }
                if (Convert.ToString(row.Cells[0].Value).Contains("."))
                {
                    recipeGroceryItemsOK = false;
                }
            }

            if (recipeNameIsSet && dropDownsAreSet && noServingsIsSet && recipeGroceryItemsOK)
            {
                inputOK = true;
            }

            return inputOK;
        }

        private void updateOutdatedDatabaseEntries(Recipe newRecipe)
        {
            Recipe oldRecipe = SQL.GetRecipe(newRecipe.Name);

            foreach (GroceryItem item in newRecipe.Ingredients)
            {
                oldRecipe.Ingredients.Remove(oldRecipe.Ingredients.Find(old_ingr => old_ingr.Name == item.Name && old_ingr.Unit == item.Unit)); // tilbage skal gerne være de gamle items der skal slettes og evt nye items der ikke endnu er tilføjet i db 
            }

            foreach (GroceryItem item in newRecipe.Twists)
            {
                oldRecipe.Twists.Remove(oldRecipe.Twists.Find(old_ingr => old_ingr.Name == item.Name && old_ingr.Unit == item.Unit)); // tilbage skal gerne være de gamle items der skal slettes og evt nye items der ikke endnu er tilføjet i db 
            }

            foreach(string leftover in newRecipe.ProducesLeftovers)
            {
                oldRecipe.ProducesLeftovers.Remove(leftover);
            }

            foreach (string leftover in newRecipe.UsesLeftovers)
            {
                oldRecipe.UsesLeftovers.Remove(leftover);
            }

            foreach (string tag in newRecipe.Tags)
            {
                oldRecipe.Tags.Remove(tag);
            }
            //discardRecipe.Ingredients = recipe.Ingredients.ToArray().Except(recipe.Ingredients.ToArray());

            SQL.RemoveItems(oldRecipe);
        }

        private List<string> GetLeftovers(DataGridView dgw)
        {
            List<string> itemList = new List<string>();

            foreach (DataGridViewRow row in dgw.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    itemList.Add( Convert.ToString( row.Cells[0].Value).ToLower());
                }
            }
            return itemList;

        }

        private List<Backend.GroceryItem> GetGroceryItems(DataGridView dgw)
        {
            List<Backend.GroceryItem> groceryItemList = new List<Backend.GroceryItem>();

            foreach (DataGridViewRow row in dgw.Rows)
            {
                string itemName = Convert.ToString( row.Cells[2].Value ).ToLower().Trim();
                string category = Convert.ToString( row.Cells[3].Value );
                
                if (itemName != "")
                {
                    Backend.GroceryItem groceryItem = new Backend.GroceryItem(itemName);
                    groceryItem.Quantity = Convert.ToSingle(row.Cells[0].Value);
                    Console.WriteLine("DEBUG: Quantity for " + itemName + " is " + groceryItem.Quantity.ToString());
                    groceryItem.Unit = Convert.ToString( row.Cells[1].Value ).Trim();
                    groceryItem.Category = category;
                    groceryItem.BasicItem = Convert.ToBoolean(row.Cells[4].Value);
                    groceryItemList.Add(groceryItem);
                }
            }
            return groceryItemList;
        }

        //DEPRECATED
        //private List<Backend.GroceryItem> GetIngredients()
        //{
        //    List<Backend.GroceryItem> groceryItemList = new List<Backend.GroceryItem>();

        //    foreach (DataGridViewRow row in dgwIngredients.Rows)
        //    {
        //        string itemName = row.Cells[dgwIngredients.Columns["dgwGroceryItemName"].Index].Value.ToString();
        //        Backend.GroceryItem groceryItem = new Backend.GroceryItem( itemName );
        //        groceryItem.Quantity = Convert.ToSingle(row.Cells[dgwIngredients.Columns["dgwQuantity"].Index].Value);
        //        groceryItem.Unit = row.Cells[dgwIngredients.Columns["dgwUnit"].Index].Value.ToString();
        //        groceryItem.Category = row.Cells[dgwIngredients.Columns["dgwCategory"].Index].Value.ToString();
        //        groceryItemList.Add(groceryItem);
        //    }

        //    return groceryItemList;
        //}

        // DEPRECATED
        //private List<Backend.GroceryItem> GetTwists() 
        //{
        //    List<Backend.GroceryItem> groceryItemList = new List<Backend.GroceryItem>();

        //    foreach (DataGridViewRow row in dgwTwists.Rows)
        //    {
        //        string itemName = row.Cells[dgwTwists.Columns["dgwGroceryItemName"].Index].Value.ToString();
        //        Backend.GroceryItem groceryItem = new Backend.GroceryItem(itemName);
        //        groceryItem.Quantity = Convert.ToSingle(row.Cells[dgwTwists.Columns["dgwQuantity"].Index].Value);
        //        groceryItem.Unit = row.Cells[dgwTwists.Columns["dgwUnit"].Index].Value.ToString();
        //        groceryItem.Category = row.Cells[dgwTwists.Columns["dgwCategory"].Index].Value.ToString();
        //        groceryItemList.Add(groceryItem);
        //    }

        //    return groceryItemList;
        //}

        // DEPRECATED 
        //private List<string> GetTags()
        //{
        //    List<string> tags = new List<string>();
        //    char[] delimiters = new char[] { ';',' ',','};
        //    string[] tagsArray = rtbTags.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        //    tags = tagsArray.ToList();
        //    return tags;
        //}

        private void dgwIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwIngredients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddEditRecipe_Load(object sender, EventArgs e)
        {
            //newRecipe = new Backend.Recipe("dummy title", IsNovelRecipe);
            cbPreparationTime.Items.AddRange(Backend.SQL.GetPreparationTimeOptions().ToArray());
            cbTotalTime.Items.AddRange(Backend.SQL.GetTotalTimeOptions().ToArray());
            cbType.Items.AddRange(Backend.SQL.GetRecipeTypeOptions().ToArray());

            IngredientsCbGroceryItemCategory.Items.Add("Vælg kategori");
            IngredientsCbGroceryItemCategory.Items.AddRange(groceryItemCategories); // Backend.SQL.GetGroceryCategoryOptions());

            TwistsCbGroceryItemCategory.Items.Add("Vælg Kategori");
            TwistsCbGroceryItemCategory.Items.AddRange(groceryItemCategories);

            if (newRecipe.ID != 0)
            {
                FillForm();
            }



            //ingredientsBindingSource = new BindingSource();
            //ingredientsBindingSource.DataSource = newRecipe.Ingredients;
            //twistsBindingSource = new BindingSource();
            //twistsBindingSource.DataSource = newRecipe.Twists;
            //tagsBindingSource = new BindingSource();
            //tagsBindingSource.DataSource = newRecipe.Tags;
            //titleBindingSource = new BindingSource();
            //titleBindingSource.DataSource = newRecipe.Name;

            //dgwIngredients.DataSource = ingredientsBindingSource;
            //dgwTwists.DataSource = twistsBindingSource;


            //if (newRecipe.ExistsInDatabase)
            //{ 
            //}

        }

        private void FillForm()
        {
            tbRecipeTitle.Text = newRecipe.Name.ToString();
            cbPreparationTime.SelectedItem = newRecipe.PreparationTime.ToString();  
            cbTotalTime.SelectedItem = newRecipe.TotalTime.ToString(); 
            cbType.SelectedItem = newRecipe.RecipeType.ToString(); //Index = recipeTypeIndex;
            tbNumberOfServings.Text = newRecipe.NumberOfServings.ToString();

            rtbNotes.Text = newRecipe.Notes; 

            lbTags.Items.AddRange(newRecipe.Tags.ToArray());
            //lvUsesLeftovers.Items.AddRange( newRecipe.UsesLeftovers.ToArray() );                                            // I NEED TO BE CHANGED TO LISTVIEWITEMS 
            //lbProducesLeftover.Items.AddRange(newRecipe.ProducesLeftovers.ToArray());

            DataGridView dgw = IngredientsDgw;
            foreach(Backend.GroceryItem item in newRecipe.Ingredients)
            {
                int rowID = dgw.Rows.Add();
                DataGridViewRow row = dgw.Rows[rowID];

                row.Cells["IngredientsTbAmount"].Value = item.Quantity;
                row.Cells["IngredientsTbUnit"].Value = item.Unit;
                row.Cells["IngredientsTbGroceryItem"].Value = item.Name; 
                row.Cells["IngredientsCbGroceryItemCategory"].Value = item.Category.ToString();
                row.Cells["IngredientsCbBasicItem"].Value = item.BasicItem;
            }

            dgw = TwistsDgw;
            foreach (Backend.GroceryItem item in newRecipe.Twists)
            {
                int rowID = dgw.Rows.Add();
                DataGridViewRow row = dgw.Rows[rowID];

                row.Cells["TwistsTbAmount"].Value = item.Quantity;
                row.Cells["TwistsTbUnit"].Value = item.Unit;
                row.Cells["TwistsTbGroceryItem"].Value = item.Name;
                row.Cells["TwistsCbGroceryItemCategory"].Value = item.Category.ToString();
                row.Cells["TwistsCbBasicItem"].Value = item.BasicItem;
            }

            foreach(string leftover in newRecipe.ProducesLeftovers)
            {
                int rowID = dgwProducesLeftovers.Rows.Add();
                DataGridViewRow row = dgwProducesLeftovers.Rows[rowID];
                row.Cells["dgwcolProducesLeftovers"].Value = leftover;
            }

            foreach (string leftover in newRecipe.UsesLeftovers)
            {
                int rowID = dgwUsesLeftovers.Rows.Add();
                DataGridViewRow row = dgwUsesLeftovers.Rows[rowID];
                row.Cells["dgwcolUsesLeftovers"].Value = leftover;
            }
        }

        private void btnAnnul_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            string newTag = tbTag.Text;
            newRecipe.Tags.Add(newTag);
            TagListBoxUpdate();
            tbTag.Clear();
        }

        private void TagListBoxUpdate()
        {
            if(lbTags.Items.Count != 0)
            {
                lbTags.Items.Clear();
            }
            foreach (string tag in newRecipe.Tags)
            {
                lbTags.Items.Add(tag);
            }
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            if (lbTags.SelectedItem != null)
            {
                object tag = lbTags.SelectedItem;
                newRecipe.Tags.Remove(tag.ToString());
                TagListBoxUpdate();
            }
            else
            {
                MessageBox.Show("Vælg et tag for at kunne slette det");
            }
        }

        private void tbTag_TextChanged(object sender, EventArgs e)
        {
            if(tbTag.Text.Length >= 3)
            {
                List<string> testTagListe = Backend.SQL.SearchTag(tbTag.Text.ToString());
                rtbHUD.Text = String.Join("\n", testTagListe); 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void IngredientsDgw_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.ToString());
            e.Cancel = true; 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbRecipeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbRecipeTitle.Text))
            {
                e.Cancel = true;
                tbRecipeTitle.Focus();
                errorProvider1.SetError(tbRecipeTitle, "Opskriften skal have en titel");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbRecipeTitle, "");
            }
        }

        private void tbTag_Click(object sender, EventArgs e)
        {
            List<string> taglist = SQL.GetAllTags();
            rtbHUD.Text = String.Join(", ", taglist);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groceries_App
{
    public partial class groceriesGUI : Form
    {
        public groceriesGUI()
        {
            InitializeComponent();
        }

        private void groceriesGUI_Load(object sender, EventArgs e)
        {
            SQLlogin loginprompt = new SQLlogin();
            loginprompt.Show();
            loginprompt.Activate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRecipe();
        }

        private void btnUpdServStat_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdRec_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btnUpdRec fired..");
            if (lbRet.Items.Count > 0)
            {
                Console.WriteLine("btnUpdRec fired. lbRetItemsCount > 0");
                lbRet.Items.Clear();
            }
            Console.WriteLine("moving on ..");
            List<string> lRetter = Backend.SQL.GetRecipes();
            foreach (string ret in lRetter)
            {
                lbRet.Items.Add(ret);
            }
        }

        //private void btnShowIngr_Click(object sender, EventArgs e)
        //{
        //    string selectRet = lbRet.SelectedItem.ToString();
        //    lblRetHeader.Text = selectRet;

        //    List<string> lTags = Backend.SQL.getTags(selectRet);
        //    string textTags = String.Join(", ", lTags);
        //    lblRetTags.Text = "Tags: " + textTags;

        //    List<string> lIngredienser = Backend.SQL.getIngredienser(selectRet)[0];
        //    string textIngredienser = String.Join("\n", lIngredienser);
        //    rtbIngredienser.Text = textIngredienser;

        //    string sPrepTime = Backend.SQL.getPrepTime(selectRet);
        //    lblPrepTime.Text = "Tilberedningstid: " + sPrepTime + " Minutter";
        //}       

        private void btnAddToShopList_Click(object sender, EventArgs e)
        {
            string selectedRecipe = lbRet.SelectedItem.ToString();
            Backend.Recipe recipe = Backend.SQL.GetRecipe(selectedRecipe);

            //Backend.shopList.AddRecipe(recipe);
            AddRecipeToShoppingList add_recipe_prompt = new AddRecipeToShoppingList(recipe);

            add_recipe_prompt.Show();
        }

        private void btnGenShopList_Click(object sender, EventArgs e)
        {
            string liste = Backend.shopList.GenerateShopList() ;
            MessageBox.Show(liste, "Indkøbslisten");
        }

        private void lbRet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRet.SelectedItem != null )
            {
                ShowRecipe(lbRet.SelectedItem.ToString());
            }
        }

        private void SearchRecipe()
        {
            string key = tbSearch.Text;
            List<string> lRetter = Backend.SQL.SearchRecipe(key);
            if (lbRet.Items.Count > 0)
            {
                lbRet.Items.Clear();
            }
            foreach (string ret in lRetter)
            {
                lbRet.Items.Add(ret);
            }
        }

        private void ShowRecipe(string recipeName)
        {
            Backend.Recipe recipe = Backend.SQL.GetRecipe(recipeName);

            lblRetHeader.Text = recipe.Name;
            lblPrepTime.Text = "Arbejdstid: " + recipe.PreparationTime.ToString() + "min   Tilberedningstid: " + recipe.TotalTime.ToString() + " min";
            lblRetTags.Text = "Tags: " + String.Join(", ", recipe.Tags);
            rtbIngredienser.Text = getIngredientsTextString(recipe);
            rtbNoter.Text = recipe.Notes;
        }

        private string getIngredientsTextString(Backend.Recipe recipe)
        {
            string ingredientTextString = "";
            foreach (Backend.GroceryItem ingredient in recipe.Ingredients)
            {
                ingredientTextString += ingredient.Quantity.ToString() + " " + ingredient.Unit + " " + ingredient.Name + "\n";
            }

            ingredientTextString += "\n\n Eventuelt: \n";

            foreach (Backend.GroceryItem ingredient in recipe.Twists)
            {
                ingredientTextString += ingredient.Name + "\n";
            }
            if (recipe.UsesLeftovers.Count != 0)
            {
                ingredientTextString += "\n\n Rester der kan tilføjes: \n";
                ingredientTextString += String.Join("\n", recipe.UsesLeftovers);
            }
            return ingredientTextString;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SearchRecipe();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchRecipe();
            }
        }

        private void labelServerStatus_Click(object sender, EventArgs e)
        {
            Backend.SQL.testConnection();
            lblServerStatus.Text = "SQL server " + Backend.SQL.ConnectionStatus;
        }

        private void btnAddEditDish_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG: bnAddEditDish has been clicked... ");
            //Backend.Recipe recipe = new Backend.Recipe("dummytitle", false);
            Backend.Recipe recipe = new Backend.Recipe(" ", false);
            AddEditRecipe add_edit_recipe_prompt = new AddEditRecipe(recipe);
            add_edit_recipe_prompt.Visible = true;
            add_edit_recipe_prompt.Show();
        }

        private void rtbNoter_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTestConsole_Click(object sender, EventArgs e)
        {
            TestConsole testKonsol = new TestConsole();
            testKonsol.Visible = true;
            testKonsol.Show();
        }

        private void btnEditDish_Click(object sender, EventArgs e)
        {
            {
                Console.WriteLine("DEBUG: bnAddEditDish for editing has been clicked... ");
                //Backend.Recipe recipe = new Backend.Recipe("dummytitle", false);
                if (lbRet.SelectedItem != null)
                {
                    string recipeTitle = lbRet.SelectedItem.ToString();
                    Backend.Recipe recipe = Backend.SQL.GetRecipe(recipeTitle);
                    AddEditRecipe add_edit_recipe_prompt = new AddEditRecipe(recipe);
                    add_edit_recipe_prompt.Visible = true;
                    add_edit_recipe_prompt.Show();
                }
            }
        }

        private void btnAddLooseItems_Click(object sender, EventArgs e)
        {
            AddLooseItems addLooseItemsPrompt = new AddLooseItems();

            addLooseItemsPrompt.Show();
        }

        private void rtbIngredienser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

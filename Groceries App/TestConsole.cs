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
    public partial class TestConsole : Form
    {
        public TestConsole()
        {
            InitializeComponent();
            List<string> availableGroceryItemCategories = Backend.SQL.GetGroceryCategoryOptions();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TestConsole_Load(object sender, EventArgs e)
        {
            Backend.Recipe recipe = Backend.testing.GenerateDummyRecipe();
            groceryItemBindingSource.DataSource = recipe.Ingredients;
            tagsBindingSource.DataSource = recipe.Tags;
            lbTags.DataSource = tagsBindingSource;

            Category.Items.Add("Select Category");
            Category.Items.AddRange(Backend.SQL.GetGroceryCategoryOptions());

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

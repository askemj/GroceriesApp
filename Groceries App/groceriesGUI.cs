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
            SQLlogin loginprompt = new SQLlogin();
            loginprompt.Show(); 
        }

        private void groceriesGUI_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchRec();
        }

        private void btnUpdServStat_Click(object sender, EventArgs e)
        {
            if ( Backend.SQL.testConnection() )
            {
                lblServerStat.Text = "Online";
            }
            else
            {
                lblServerStat.Text = "Offline";
            }
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
            List<string> lRetter = Backend.SQL.getRetter();
            foreach (string ret in lRetter)
            {
                lbRet.Items.Add(ret);
            }
        }

        private void btnShowIngr_Click(object sender, EventArgs e)
        {
            string selectRet = lbRet.SelectedItem.ToString();
            lblRetHeader.Text = selectRet;

            List<string> lTags = Backend.SQL.getTags(selectRet);
            string textTags = String.Join(", ", lTags);
            lblRetTags.Text = "Tags: " + textTags;

            List<string> lIngredienser = Backend.SQL.getIngredienser(selectRet);
            string textIngredienser = String.Join("\n", lIngredienser);
            rtbIngredienser.Text = textIngredienser;

            string sPrepTime = Backend.SQL.getPrepTime(selectRet);
            lblPrepTime.Text = "Tilberedningstid: " + sPrepTime + " Minutter";
        }       

        private void btnAddToShopList_Click(object sender, EventArgs e)
        {
            string selectRet = lbRet.SelectedItem.ToString();
            Backend.shopList.addRet(selectRet);
            lblNoRecOnShopList.Text = Backend.shopList.noRecOnShopList().ToString();
        }

        private void btnGenShopList_Click(object sender, EventArgs e)
        {
            string liste = Backend.shopList.genShopList();
            MessageBox.Show(liste, "Indkøbslisten");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLlogin loginPrompt = new SQLlogin();
            loginPrompt.Show();
        }

        private void lbRet_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectRet = lbRet.SelectedItem.ToString();
            lblRetHeader.Text = selectRet;

            List<string> lTags = Backend.SQL.getTags(selectRet);
            string textTags = String.Join(", ", lTags);
            lblRetTags.Text = "Tags: " + textTags;

            List<string> lIngredienser = Backend.SQL.getIngredienser(selectRet);
            string textIngredienser = String.Join("\n", lIngredienser);
            rtbIngredienser.Text = textIngredienser;

            string sPrepTime = Backend.SQL.getPrepTime(selectRet);
            lblPrepTime.Text = "Tilberedningstid: " + sPrepTime + " Minutter";
        }

        private void searchRec()
        {
            string key = tbSearch.Text;
            List<string> lRetter = Backend.SQL.searchRet(key);
            if (lbRet.Items.Count > 0)
            {
                lbRet.Items.Clear();
            }
            foreach (string ret in lRetter)
            {
                lbRet.Items.Add(ret);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            searchRec();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchRec();
            }
        }
    }
}

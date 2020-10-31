using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;

namespace Groceries_App
{
    public partial class SQLlogin : Form
    {
        public SQLlogin()
        {
            InitializeComponent();
            this.tbPass.PasswordChar = '*';
        }

        private void SQLlogin_Load(object sender, EventArgs e)
        {

        }

        private void btnServerLoginOK_Click(object sender, EventArgs e)
        {
            SqlLoginGo();
        }


        private void tbServerIP_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SqlLoginGo();
            }
        }

        private void SqlLoginGo()
        {
            string p = tbPass.Text;
            string user = tbUser.Text;
            string IP = tbServerIP.Text;

            Backend.SQL.SetupSQL(user, p, IP);
            tbPass.Text = "";
            Backend.SQL.testConnection();
            if (Backend.SQL.ConnectionStatus == "available")
            {
                this.Close();
                p = "";
            }
            else
            {
                MessageBox.Show("Error on server login. Please try again.", "SQL login error");
            }
        }
    }
}

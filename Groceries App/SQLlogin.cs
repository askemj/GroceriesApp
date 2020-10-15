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
            sqlLoginGo();
        }


        private void tbServerIP_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sqlLoginGo();
            }
        }

        private void sqlLoginGo()
        {
            string p = tbPass.Text;
            string user = tbUser.Text;
            string IP = tbServerIP.Text;

            Backend.SQL.setupSQL(user, p, IP);
            tbPass.Text = "";
            if (Backend.SQL.testConnection())
            {
                this.Close();
                p = "";
            }
            else
            {
                MessageBox.Show("Fejl ved login på SQL server. Prøv igen.", "SQL login-fejl");
            }
        }
    }
}

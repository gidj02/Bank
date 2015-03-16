using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace FormViews
{
    public partial class login_form : MetroForm
    {
        public login_form()
        {
            InitializeComponent();
        }

        private void login_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //for testing
            if (txtAccountID.Text == "admin" && txtPinCode.Text == "12345")
            {
                home_form home = new home_form();
                home.Show();
                this.Hide();
            }
        }
    }
}

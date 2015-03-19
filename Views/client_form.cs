using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class client_form : MaterialForm
    {
        string username = string.Empty;

        public client_form()
        {
            InitializeComponent();
        }

        public client_form(string username)
        {
            InitializeComponent();
            lblWelcome.Text = "Welcome " + username;
        }

        private void dgAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new pin_form("1x42dgfs", username);
        }

        private void user_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            pin_form pinForm = new pin_form();
            pinForm.Show();
            this.Dispose();
        }
    }
}

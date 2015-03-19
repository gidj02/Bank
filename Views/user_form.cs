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
    public partial class user_form : MaterialForm
    {
        string username = string.Empty;

        public user_form()
        {
            InitializeComponent();
        }

        public user_form(string username)
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
    }
}

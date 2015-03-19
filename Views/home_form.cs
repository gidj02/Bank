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
    public partial class home_form : MaterialForm
    {
        string username = string.Empty;

        public home_form()
        {
            InitializeComponent();
        }

        private void home_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            user_form userform = new user_form(username);
            userform.Show();
            this.Dispose();
        }

        private void home_form_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUsername;
        }
    }
}

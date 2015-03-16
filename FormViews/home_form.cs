using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormViews
{
    public partial class home_form : MetroForm
    {
        public home_form()
        {
            InitializeComponent();
        }

        private void tileActivate_Click(object sender, EventArgs e)
        {
            loginaccount_form login = new loginaccount_form();
            this.Hide();
            login.Show();
        }

        private void home_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tileClient_Click(object sender, EventArgs e)
        {
            newclient_form client = new newclient_form();
            this.Hide();
            client.Show();
        }

        private void tileAccount_Click(object sender, EventArgs e)
        {
            loginclient_form client = new loginclient_form();
            this.Hide();
            client.Show();
        }
    }
}

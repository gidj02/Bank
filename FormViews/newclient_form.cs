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
    public partial class newclient_form : MetroForm
    {
        public newclient_form()
        {
            InitializeComponent();
        }

        private void newclient_form_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home_form home = new home_form();
            home.Show();
            this.Hide();
        }

        private void newclient_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

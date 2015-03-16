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
    public partial class loginclient_form : MetroForm
    {
        public loginclient_form()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home_form home = new home_form();
            this.Hide();
            home.Show();
        }
    }
}

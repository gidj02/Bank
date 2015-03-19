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
    public partial class pin_form : MaterialForm
    {
        string acconumber = string.Empty;
        string username = string.Empty;

        public pin_form()
        {
            InitializeComponent();
        }

        public pin_form(string acconumber, string username)
        {
            InitializeComponent();
            this.acconumber = acconumber;
            this.username = username;
        }

        private void pin_form_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtPin;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            /*if (txtPin.Text == acconumber)
            {
                
            }
            else
            {
                MessageBox.Show("Invalid Pin Code");
            }*/
            transac_form transac = new transac_form();
            transac.Show();
            this.Dispose();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new user_form(username).Show();
            this.Dispose();
        }
    }
}

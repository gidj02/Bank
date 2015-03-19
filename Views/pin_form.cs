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
using BankLibrary.Models;
using BankLibrary.DataAccess;
using BankLibrary.Controllers;

namespace Views
{
    public partial class pin_form : MaterialForm
    {
        account_controller accountcon = new account_controller();

        int accoid;

        public pin_form()
        {
            InitializeComponent();
        }

        public pin_form(int accoid)
        {
            InitializeComponent();
            this.accoid = accoid;
        }

        private void pin_form_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtPin;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (accountcon.checkPin(txtPin.Text, accoid))
            {
                MessageBox.Show("Account Logged In!");
            }
            else
            {
                MessageBox.Show("Account Login Failed!");
                txtPin.Text = "";
            }
            /*transac_form transac = new transac_form();
            transac.Show();
            this.Dispose();*/
        }
    }
}

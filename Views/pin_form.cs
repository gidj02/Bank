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
        account account;
        int accoid;

        public pin_form()
        {
            InitializeComponent();
        }

        public pin_form(account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void pin_form_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtPin;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (accountcon.checkPin(txtPin.Text, this.account.accountid))
            {
                MessageBox.Show("Account Logged In!");
                transac_form transact = new transac_form(this.account);
                transact.Show();
                this.Hide();
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

        private void pin_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}

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
using System.Text.RegularExpressions;

namespace Views
{
    public partial class pin_form : MaterialForm
    {
        Regex pinRegex = new Regex(@"^[0-9]{6,6}$");
        account_controller accountcon = new account_controller();
        account account;
        client client;
        //int accoid;

        public pin_form()
        {
            InitializeComponent();
        }

        public pin_form(account account, client client)
        {
            InitializeComponent();
            this.account = account;
            this.client = client;
        }

        private void pin_form_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtPin;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (pinRegex.IsMatch(txtPin.Text))
            {
                if (accountcon.checkPin(txtPin.Text, this.account.accountid))
                {
                    MessageBox.Show("Account Logged In!");
                    transac_form transact = new transac_form(this.account, this.client);
                    transact.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Account Login Failed!");
                    txtPin.Text = "";
                }
            }
            else MessageBox.Show("Invalid Pin Code!"); 
        }

        private void pin_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}

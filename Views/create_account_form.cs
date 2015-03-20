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
using BankLibrary.Controllers;
using BankLibrary.DataAccess;
using BankLibrary.Models;

namespace Views
{
    public partial class create_account_form : MaterialForm
    {
        client client;
        account_controller accountcon = new account_controller();

        public create_account_form()
        {
            InitializeComponent();
        }

        public create_account_form(client client)
        {
            InitializeComponent();
            this.client = client;
            MessageBox.Show(client.email);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == client.password && txtPin.Text == txtConfirmPin.Text)
            {
                if (this.accountcon.createAccount(client.clientid, txtPin.Text, Convert.ToDecimal(txtDeposit.Text)))
                {
                    MessageBox.Show("Success! Account Created.");
                }
                else MessageBox.Show("Failed registration.");

                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password/Pin Code Mismatch.");
            }
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConfirmPin.Text = "";
            txtDeposit.Text = "";
            txtPassword.Text = "";
            txtPin.Text = "";
        }
    }
}

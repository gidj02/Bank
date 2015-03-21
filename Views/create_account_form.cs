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
using System.Text.RegularExpressions;

namespace Views
{
    public partial class create_account_form : MaterialForm
    {
        client client;
        account_controller accountcon = new account_controller();
        client_controller clientcon = new client_controller();
        Regex pinRegex = new Regex(@"^[0-9]{6,6}$");
        Regex passwordRegex = new Regex(@"^(?=.{6,})(?=.*[a-z])(?=.*[A-Z])(?=.*[\d]).*$");
        Regex amountRegEX = new Regex(@"^[0-9]+(\.[0-9]{1,2})?$");
        
        public create_account_form()
        {
            InitializeComponent();
        }

        public create_account_form(client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(pinRegex.IsMatch(txtPin.Text) && passwordRegex.IsMatch(txtPassword.Text) && amountRegEX.IsMatch(txtDeposit.Text))
            {
                if (this.clientcon.verifyPass(txtPassword.Text, client.clientid))
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
            else MessageBox.Show("Please check all field!");
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

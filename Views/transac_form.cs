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
using BankLibrary.Models;
using BankLibrary.DataAccess;
using System.Text.RegularExpressions;


namespace Views
{
    public partial class transac_form : MaterialForm
    {
        account_controller accountcon = new account_controller();
        transaction_controller transcon = new transaction_controller();
        client_controller clientcon = new client_controller();

        account account;
        client client;
        loan_balance loanbalance;

        Regex pinRegex = new Regex(@"^[0-9]{6,6}$");
        Regex passwordRegex = new Regex(@"^(?=.{6,})(?=.*[a-z])(?=.*[A-Z])(?=.*[\d]).*$");

        public transac_form()
        {
            InitializeComponent();
        }

        public transac_form(account account, client client)
        {
            InitializeComponent();
            this.account = account;
            this.client = client;
        }

        private void transac_form_Load(object sender, EventArgs e)
        {
            transcon.setBalanceandLoan(this.account.accountid);
            updateLoanandBalance();
            dgLogs.DataSource = this.transcon.viewTransactions(account.accountid);
        }

        public void updateLoanandBalance()
        {
            loanbalance = transcon.getBalanceandLoan();
            lblBalance.Text = "Balance: " + loanbalance.balanceAmount.ToString();
            lblLoan.Text = "Loan: " + loanbalance.loanAmount.ToString();
        }

        private void btnWithdraw_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (validationAmount(txtWithdraw.Text))
                {
                    if (transcon.clientWithdraw(this.account.accountid, Convert.ToDecimal(txtWithdraw.Text)))
                    {
                        MessageBox.Show("Withdrawal Success!");
                        updateLoanandBalance();
                        txtWithdraw.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Withdrawal Failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Withdrawal Failed!");
                }
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            dgLogs.DataSource = this.transcon.viewTransactions(account.accountid);
        }

        private void btnDeposit_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (validationAmount(txtDeposit.Text))
                {
                    if (transcon.clientDeposit(this.account.accountid, Convert.ToDecimal(txtDeposit.Text)))
                    {
                        MessageBox.Show("Deposit Success!");
                        txtDeposit.Text = "";
                        updateLoanandBalance();
                    }
                    else
                    {
                        MessageBox.Show("Deposit Failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Deposit Failed!");
                }
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            dgLogs.DataSource = this.transcon.viewTransactions(account.accountid);
        }

        private void btnEncash_Click(object sender, EventArgs e)
        {
            try
            {
                if (validationAmount(txtEncash.Text))
                {

                    if (transcon.clientEncash(this.account.accountid, Convert.ToDecimal(txtEncash.Text)))
                    {
                        MessageBox.Show("Encashment Success!");
                        updateLoanandBalance();
                        txtEncash.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Encashment Failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Encashment Failed!");
                }
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            dgLogs.DataSource = this.transcon.viewTransactions(account.accountid);
        }

        private void btnChangeAcc_Click(object sender, EventArgs e)
        {
            client_form clientForm = new client_form(client);
            clientForm.Show();
            this.Dispose();
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            if (pinRegex.IsMatch(txtOldPin.Text) &&
                pinRegex.IsMatch(txtConfirmPin.Text) &&
                pinRegex.IsMatch(txtNewPin.Text))
            {
                if (txtNewPin.Text == txtConfirmPin.Text)
                {
                    if (accountcon.changePin(account.accountid, txtOldPin.Text, txtNewPin.Text))
                    {
                        MessageBox.Show("Pin successfully changed!");
                    }
                    else MessageBox.Show("Changing of pin failed");
                }
                else MessageBox.Show("Passsword did not match!");
            }
            else MessageBox.Show("Invalid Pin Code!");
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (pinRegex.IsMatch(txtDelPin.Text) && passwordRegex.IsMatch(txtDelPass.Text))
            {
                if (this.clientcon.verifyPass(txtDelPass.Text, client.clientid) &&
                               this.accountcon.verifyPin(txtDelPin.Text, account.accountid))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this client account?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (accountcon.deleteAcc(account.accountid, txtDelPin.Text))
                        {
                            MessageBox.Show("Account Successfully Deleted!");
                            new client_form(client).Show();
                            this.Dispose();
                        }
                    }
                    else MessageBox.Show("Invalid Password/Pin!");
                }

            }
            else MessageBox.Show("Invalid Password/Pin!");
        }

        private bool validationAmount(string amount)
        {
            Regex amountReg = new Regex(@"^[0-9]+(\.[0-9]{1,2})?$");
            Match accept = amountReg.Match(amount);
            if (!accept.Success)
            {
                return false;
            }
            else return true; 
        }

        private void transac_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

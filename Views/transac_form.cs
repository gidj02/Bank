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


namespace Views
{
    public partial class transac_form : MaterialForm
    {
        account_controller accountcon = new account_controller();
        transaction_controller transcon = new transaction_controller();
        
        account account;
        client client;
        loan_balance loanbalance;

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
        }

        public void updateLoanandBalance()
        {
            loanbalance = transcon.getBalanceandLoan();
            lblBalance.Text = "Balance: " + loanbalance.balanceAmount.ToString();
            lblLoan.Text = "Loan: " + loanbalance.loanAmount.ToString();
        }

        private void btnWithdraw_Click_1(object sender, EventArgs e)
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

        private void btnDeposit_Click_1(object sender, EventArgs e)
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

        private void btnEncash_Click(object sender, EventArgs e)
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

        private void btnChangeAcc_Click(object sender, EventArgs e)
        {
            client_form clientForm = new client_form(client);
            clientForm.Show();
            this.Dispose();
        }
    }
}

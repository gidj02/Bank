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
        
        account account;
        loan_balance loanbalance;
        char transacType;


        public transac_form()
        {
            InitializeComponent();
        }

        public transac_form(account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void transac_form_Load(object sender, EventArgs e)
        {
            accountcon.setBalanceandLoan(this.account.accountid);
            updateLoanandBalance();
        }

        
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            transacType = 'w';

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            transacType = 'd';
        }

        private void btnEncashment_Click(object sender, EventArgs e)
        {
            transacType = 'e';
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            switch (transacType)
            {
                case 'w': 
                    if (accountcon.clientWithdraw(this.account.accountid, Convert.ToDecimal(txtAmount.Text)))
                    {
                        MessageBox.Show("Withdrawal Success!");
                    }
                    else
                    {
                        MessageBox.Show("Withdrawal Failed!");
                    }
                    break;
                case 'd':
                    if (accountcon.clientDeposit(this.account.accountid, Convert.ToDecimal(txtAmount.Text)))
                    {
                        MessageBox.Show("Deposit Success!");
                    }
                    else
                    {
                        MessageBox.Show("Deposit Failed!");
                    }
                    break;
                case 'e': break;
            }

            updateLoanandBalance();
        }

        public void updateLoanandBalance()
        {
            loanbalance = accountcon.getBalanceandLoan();
            lblBalance.Text = "Balance: " + loanbalance.balanceAmount.ToString();
            lblLoan.Text = "Loan: " + loanbalance.loanAmount.ToString();
        }
    }
}

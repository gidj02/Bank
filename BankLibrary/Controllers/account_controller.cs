using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary.DataAccess;
using BankLibrary.Models;
using System.Data;

namespace BankLibrary.Controllers
{
    public class account_controller
    {
        account_dataaccess account = new account_dataaccess();

        public DataTable listAccount(int userid)
        {
            return this.account.listAccount(userid);
        }

        public account setAccount(int accoid)
        {
            return this.account.setAccount(accoid);
        }

        public account getCurrentAccount()
        {
            return this.account.getCurrentAccount();
        }

        public bool checkPin(string pincode, int accoid)
        {
            return this.account.checkPin(pincode, accoid);
        }

        public void setBalanceandLoan(int accoid)
        {
            this.account.setBalanceandLoan(accoid);
        }

        public loan_balance getBalanceandLoan() 
        {
            return this.account.getBalanceandLoan();
        }

        public bool clientWithdraw(int accoid, decimal amount)
        {
            return this.account.clientWithdraw(accoid, amount);
        }

        public bool clientDeposit(int accoid, decimal amount)
        {
            return this.account.clientDeposit(accoid, amount);
        }
    }
}

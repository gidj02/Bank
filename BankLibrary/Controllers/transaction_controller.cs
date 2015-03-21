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
    public class transaction_controller
    {
        transaction_dataaccess trans = new transaction_dataaccess();

        public void setBalanceandLoan(int accoid)
        {
            this.trans.setBalanceandLoan(accoid);
        }

        public loan_balance getBalanceandLoan()
        {
            return this.trans.getBalanceandLoan();
        }

        public bool clientWithdraw(int accoid, decimal amount)
        {
            return this.trans.clientWithdraw(accoid, amount);
        }

        public bool clientDeposit(int accoid, decimal amount)
        {
            return this.trans.clientDeposit(accoid, amount);
        }

        public bool clientEncash(int accoid, decimal amount)
        {
            return this.trans.clientEncash(accoid, amount);
        }

        public DataTable viewTransactions(int accoid)
        {
            return this.trans.viewTransactions(accoid);
        }

    }
}

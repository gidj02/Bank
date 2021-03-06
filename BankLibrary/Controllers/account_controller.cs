﻿using System;
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

        public bool createAccount( int clientid, string pin, decimal deposit)
        {
            return this.account.createAccount(clientid, pin, deposit);
        }

        public bool changePin(int clientid, string oldPin, string newPin)
        {
            return this.account.changePin(clientid, oldPin, newPin);
        }
        public bool deleteAcc(int clientid, string pin)
        {
            return this.account.deleteAcc(clientid, pin);
        }

        public bool verifyPin(string pin, int accoid)
        {
            return this.account.verifyPin(pin, accoid);
        }
    }
}

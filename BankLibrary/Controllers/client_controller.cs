using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary.DataAccess;
using BankLibrary.Models;

namespace BankLibrary.Controllers
{
    public  class client_controller
    {
        client_dataaccess clientda = new client_dataaccess();

        public bool checkClientLogin(string username, string password)
        {
            return clientda.checkClientLogin(username, password);
        }
        public client getClient()
        {
            return this.clientda.getClient();
        }

        public bool createClient(string firstname, string middlename, string lastname, string address, string number, string email, string username, string password)
        {
            return this.clientda.createClient(firstname, middlename, lastname, address, number, email, username, password);
        }

        public bool updateClient(int clientid, string firstname, string middlename, string lastname, string address, string number, string email, string username)
        {
            return this.clientda.updateClient(clientid,firstname, middlename, lastname, address, number, email, username);
        }
    }
}


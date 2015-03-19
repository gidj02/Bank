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

        public List<client> getClient()
        {
            return this.clientda.getClient();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary.Models
{
    public class account
    {
        public int accountid { get; set; }
        public int clientid { get; set; }
        public DateTime dateCreated { get; set; }
        public bool status { get; set; }
        public string pin { get; set; }
    }
}

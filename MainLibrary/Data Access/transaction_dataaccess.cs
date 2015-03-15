using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Data_Access
{
    class transaction_dataaccess
    {
        private static string connStr = @"Data Source=GINODEJESUS\SQLEXPRESS14; Integrated Security=TRUE; Initial Catalog= db_bank;";
        public SqlConnection conn = new SqlConnection(connStr);

        public void setConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else
                {
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error on Connection");
            }
        }// end connection function
    }
}

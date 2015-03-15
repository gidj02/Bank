using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Data_Access
{
    class client_dataaccess
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

        public void addClient()
        {
            try
            {
                setConnection();

                using (SqlCommand cmd = new SqlCommand("add_client", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
                    //cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;
                    //insert parameters here

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error in adding Client");
            }
            finally
            {
                setConnection();
            }
        }

        public DataTable viewClient()
        {
            DataTable dt = new DataTable();
            try
            {
                setConnection();

                using (SqlCommand cmd = new SqlCommand("view_client", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
                    //cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;
                    //insert parameters here

                    var data = new SqlDataAdapter(cmd);
                    data.Fill(dt);
                }

                return dt;
            }
            catch (Exception)
            {
                throw new Exception("Error in viewing Client");
            }
            finally
            {
                setConnection();
            }
        }
    }
}

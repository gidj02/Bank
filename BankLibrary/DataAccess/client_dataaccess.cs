using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary.Models;

namespace BankLibrary.DataAccess
{
    class client_dataaccess
    {
        private static string connStr = @"Data Source=.; Integrated Security=TRUE; Initial Catalog= DBBank;";
        public SqlConnection conn = new SqlConnection(connStr);
        List<client> client = new List<client>();

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
        }// end

        public bool checkClientLogin(string username, string password)
        {
            int value = 0;
            try
            {
                setConnection();
                using (SqlCommand cmd = new SqlCommand("loginClient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                    SqlParameter ret = new SqlParameter("@return", SqlDbType.Int);
                    ret.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ret);
                    cmd.ExecuteNonQuery();
                    value = Convert.ToInt32(ret.Value);
                }

                if (value == 1)
                {
                    setConnection();
                    setClient(username);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                setConnection();
            }
        }

        public void setClient(string username)
        {
            try
            {
                setConnection();
                SqlCommand cmd = new SqlCommand("getUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    client c = new client(){
                        firstname = reader["firstName"].ToString(),
                        middlename = reader["middleName"].ToString(),
                        lastname = reader["lastName"].ToString(),
                        address = reader["address"].ToString(),
                        email = reader["email"].ToString(),
                        contact = reader["contactNumber"].ToString(),
                        username = reader["userName"].ToString(),
                        password = reader["password"].ToString()
                    };
                    client.Add(c);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                setConnection();
            }
        }
    
        public List<client> getClient()
        {
            return this.client;
        }
    }
}

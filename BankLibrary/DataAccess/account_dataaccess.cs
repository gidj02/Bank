using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary.Models;
using System.Data.SqlClient;
using System.Data;

namespace BankLibrary.DataAccess
{
    class account_dataaccess
    {
        private static string connStr = @"Data Source=.; Integrated Security=TRUE; Initial Catalog= DBBank;";
        public SqlConnection conn = new SqlConnection(connStr);
        account account;


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

        public DataTable listAccount(int userid)
        {
            DataTable dt = new DataTable();

            try
            {
                setConnection();
                SqlCommand cmd = new SqlCommand("getAccount", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw new Exception("error selection");
            }
            finally
            {
                setConnection();
            }

            return dt;
        }

        public account setAccount(int accoid)
        {
            try
            {
                setConnection();
                SqlCommand cmd = new SqlCommand("getAccountInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@accoid", SqlDbType.Int).Value = accoid;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    account a = new account()
                    {
                        clientid = (int)reader["clientId"],
                        accountid = (int)reader["accountId"],
                        status = (bool)reader["status"],
                        dateCreated = Convert.ToDateTime(reader["dateCreated"]),
                        pin = reader["pin"].ToString()
                    };
                    account = a;
                }

                return this.account;
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

        public account getCurrentAccount()
        {
            return this.account;
        }

        public bool checkPin(string pincode, int accoid)
        {
            int value = 0;
            try
            {
                setConnection();
                using (SqlCommand cmd = new SqlCommand("loginAccount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@pin", SqlDbType.VarChar).Value = pincode;
                    cmd.Parameters.Add("@accountId", SqlDbType.VarChar).Value = accoid;

                    SqlParameter ret = new SqlParameter("@return", SqlDbType.Int);
                    ret.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ret);
                    cmd.ExecuteNonQuery();
                    value = Convert.ToInt32(ret.Value);
                }

                if (value == 1)
                {
                    return true;
                }

                return false;
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

        public bool createAccount(int clientid, string pin, decimal deposit)
        {
            setConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand("createAccount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientid;
                    cmd.Parameters.Add("@pin", SqlDbType.NVarChar).Value = pin;
                    cmd.Parameters.Add("@initialDeposit", SqlDbType.Decimal).Value = deposit;
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
                throw new Exception("Error in Creating Account");
            }
            finally
            {
                setConnection();
            }
        }

     

        public bool changePin(int accountid, string oldPin, string newPin)
        {
            try
            {
                setConnection();
                using (SqlCommand cmd = new SqlCommand("changePin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@accountId", SqlDbType.Int).Value = accountid;
                    cmd.Parameters.Add("@oldPin", SqlDbType.NVarChar).Value = oldPin;
                    cmd.Parameters.Add("@newPin", SqlDbType.NVarChar).Value = newPin;
                    cmd.ExecuteNonQuery();
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

            return true;
        }
         

        public bool deleteAcc(int accountid, string pin)
        {
            try
            {
                setConnection();
                using (SqlCommand cmd = new SqlCommand("deleteAccount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@accountId", SqlDbType.Int).Value = accountid;
                    cmd.Parameters.Add("@pin", SqlDbType.NVarChar).Value = pin;
                    cmd.ExecuteNonQuery();
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

            return true;
        }

        public bool verifyPin(string pin, int accoid)
        {
            int value = 0;
            setConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand("verifyPin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@pin", SqlDbType.NVarChar).Value = pin;
                    cmd.Parameters.Add("@accountId", SqlDbType.Int).Value = accoid;
                    cmd.ExecuteNonQuery();

                    SqlParameter ret = new SqlParameter("@return", SqlDbType.Int);
                    ret.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ret);
                    cmd.ExecuteNonQuery();
                    value = Convert.ToInt32(ret.Value);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error in Verify Pin");
            }
            finally
            {
                setConnection();
            }

            if (value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

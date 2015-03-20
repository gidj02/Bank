using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary.Models;
using System.Data.SqlClient;

namespace BankLibrary.DataAccess
{
    public class transaction_dataaccess
    {
        loan_balance loanbalance;
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

        public void setBalanceandLoan(int accoid)
        {
            try
            {
                setConnection();
                SqlCommand cmd = new SqlCommand("getBalanceandLoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@accoid", SqlDbType.NVarChar).Value = accoid;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    loan_balance lb = new loan_balance()
                    {
                        loanAmount = (decimal)reader["currentLoan"],
                        balanceAmount = (decimal)reader["currentBalance"]
                    };
                    this.loanbalance = lb;
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
        public bool clientWithdraw(int accoid, decimal amount)
        {
            int value = 0;
            try
            {
                setConnection();
                using (SqlCommand cmd = new SqlCommand("withdraw", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@accountId", SqlDbType.VarChar).Value = accoid;
                    cmd.Parameters.Add("@amount", SqlDbType.VarChar).Value = amount;

                    SqlParameter ret = new SqlParameter("@return", SqlDbType.Int);
                    ret.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ret);
                    cmd.ExecuteNonQuery();
                    value = Convert.ToInt32(ret.Value);
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

            if (value == 1)
            {
                setBalanceandLoan(accoid);
                return true;
            }
            else
            {
                return false;
            }
        }

        public loan_balance getBalanceandLoan()
        {
            return this.loanbalance;
        }

        public bool clientDeposit(int accoid, decimal amount)
        {
            try
            {
                setConnection();
                using (SqlCommand cmd = new SqlCommand("deposit", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@accountId", SqlDbType.VarChar).Value = accoid;
                    cmd.Parameters.Add("@amount", SqlDbType.VarChar).Value = amount;
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

            setBalanceandLoan(accoid);
            return true;
        }

        public bool clientEncash(int accoid, decimal amount)
        {
            int value = 0;
            try
            {
                setConnection();
                using (SqlCommand cmd = new SqlCommand("encash", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@accountId", SqlDbType.VarChar).Value = accoid;
                    cmd.Parameters.Add("@amount", SqlDbType.VarChar).Value = amount;

                    SqlParameter ret = new SqlParameter("@return", SqlDbType.Int);
                    ret.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ret);
                    cmd.ExecuteNonQuery();
                    value = Convert.ToInt32(ret.Value);
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

            if (value == 1)
            {
                setBalanceandLoan(accoid);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

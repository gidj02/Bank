﻿using System;
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

        public void setAccount(int accoid)
        {
            try
            {
                setConnection();
                SqlCommand cmd = new SqlCommand("getAccontInfo", conn);
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
    }
}

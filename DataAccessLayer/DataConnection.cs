using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataConnection
    {
        public static string Constring = "Data Source=BesarKutleshi;Initial Catalog=BankManagment;Integrated Security=True";
        public static async Task<SqlConnection> Connection()
        {
            try
            {
                SqlConnection con = new SqlConnection(Constring);
                await con.OpenAsync();
                return con;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SqlCommand Command(SqlConnection con, string cmdText, CommandType commandType)
        {
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = commandType;
            return cmd;
        }

        public static async Task<int> GetValue(SqlCommand cmd)
        {
            cmd.Parameters.Add(new SqlParameter("@Value", System.Data.SqlDbType.Int));
            cmd.Parameters["@Value"].Direction = System.Data.ParameterDirection.Output;
            await cmd.ExecuteNonQueryAsync();
            return int.Parse(cmd.Parameters["@Value"].Value.ToString());
        }

        public static async Task<T> Result<T>(int value, T obj)
        {
            if (value == 1)
            {
                return await Task.FromResult(obj);
            }
            else
                return await Task.FromResult(default(T));
        }
    }
}

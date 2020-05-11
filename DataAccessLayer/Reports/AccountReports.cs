using EntityLayer.Reports;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reports
{
    public class AccountReports
    {
		private string[] Months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public async Task<List<DataPoint>> GetRaports(int clientid,string procedure)
        {
			try
			{
				List<DataPoint> Data = null;
				for (int i = 0; i < Months.Length; i++)
				{
					using(var con = await DataConnection.Connection())
					{
						var cmd = DataConnection.Command(con, procedure, CommandType.StoredProcedure);
						cmd.Parameters.AddWithValue("@Month", i + 1);
						cmd.Parameters.AddWithValue("@ClientID", clientid);
						SqlDataReader sdr = await cmd.ExecuteReaderAsync();
						if (sdr.HasRows)
						{
							if(Data == null)
								Data = new List<DataPoint>();
							while (await sdr.ReadAsync())
							{
								Data.Add(new DataPoint(Months[i], decimal.Parse(sdr["Value"].ToString())));
							}
						}
					}
				}
				return Data;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}

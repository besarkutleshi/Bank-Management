using EntityLayer.Reports;
using EntityLayer.Transactions;
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

		public async Task<List<Deposit>> GetDeposits(int clientid)
		{
			try
			{
				List<Deposit> deposits = null;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_GetLastDeposits", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@ClientID", clientid);
					SqlDataReader sdr = await cmd.ExecuteReaderAsync();
					if (sdr.HasRows)
					{
						deposits = new List<Deposit>();
						while (await sdr.ReadAsync())
						{
							Deposit obj = new Deposit();
							obj.Amount = double.Parse(sdr["Amount"].ToString());
							obj.Description = sdr["Description"].ToString();
							deposits.Add(obj);
						}
					}
				}
				return deposits;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<Transfer>> GetTransfers(int clientid)
		{
			try
			{
				List<Transfer> transfers = null;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_GetLastTransfers", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@ClientID", clientid);
					SqlDataReader sdr = await cmd.ExecuteReaderAsync();
					if (sdr.HasRows)
					{
						transfers = new List<Transfer>();
						while (await sdr.ReadAsync())
						{
							Transfer obj = new Transfer();
							obj.Amount = double.Parse(sdr["Amount"].ToString());
							obj.Description = sdr["Description"].ToString();
							transfers.Add(obj);
						}
					}
				}
				return transfers;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<WithDrawal>> GetWithDrawals(int clientid)
		{
			try
			{
				List<WithDrawal> withDrawals = null;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_GetLastWithDrawals", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@ClientID", clientid);
					SqlDataReader sdr = await cmd.ExecuteReaderAsync();
					if (sdr.HasRows)
					{
						withDrawals = new List<WithDrawal>();
						while (await sdr.ReadAsync())
						{
							WithDrawal obj = new WithDrawal();
							obj.Amount = double.Parse(sdr["Amount"].ToString());
							obj.Description = sdr["Description"].ToString();
							obj.ExecutionDate = Convert.ToDateTime(sdr["ExecutionDate"]);
							withDrawals.Add(obj);
						}
					}
				}
				return withDrawals;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

using DataAccessLayer.Interface;
using EntityLayer.Accounts;
using EntityLayer.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Cards
{
    public class TransactionRepository : IInsert<Deposit>,IInsert<Transfer>,IInsert<WithDrawal>,IGetObject<Deposit>
    {
        public async Task<ActionResult<Deposit>> Insert(Deposit obj)
        {
			try
			{
				int value = 0;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_MakeDeposit", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@FullName", obj.FullName);
					cmd.Parameters.AddWithValue("@ClientID", obj.ClientID);
					cmd.Parameters.AddWithValue("@ExecutionDate", obj.ExecutionDate);
					cmd.Parameters.AddWithValue("@Description", obj.Description);
					cmd.Parameters.AddWithValue("@CardNumber", obj.CardNumber);
					cmd.Parameters.AddWithValue("@AccountNumber", obj.AccountNumber);
					cmd.Parameters.AddWithValue("@Amount", obj.Amount);
					value = await DataConnection.GetValue(cmd); 
				}
				return await DataConnection.Result(value, obj);
			}
			catch (Exception)
			{
				throw;
			}
        }

		public async Task<ActionResult<Transfer>> Insert(Transfer obj)
		{
			try
			{
				int value = 0;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_MakeTransfer", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@FullName", obj.FullName);
					cmd.Parameters.AddWithValue("@ClientID", obj.ClientID);
					cmd.Parameters.AddWithValue("@ExecutionDate", obj.ExecutionDate);
					cmd.Parameters.AddWithValue("@Description", obj.Description);
					cmd.Parameters.AddWithValue("@CardNumber", obj.CardNumber);
					cmd.Parameters.AddWithValue("@AccountNumber", obj.AccountNumber);
					cmd.Parameters.AddWithValue("@ToAccountNumber", obj.ToAccountNumber);
					cmd.Parameters.AddWithValue("@Amount", obj.Amount);
					value = await DataConnection.GetValue(cmd);
				}
				return await DataConnection.Result(value, obj);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<ActionResult<WithDrawal>> Insert(WithDrawal obj)
		{
			try
			{
				int value = 0;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_MakeWithDrawal", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@FullName", obj.FullName);
					cmd.Parameters.AddWithValue("@ClientID", obj.ClientID);
					cmd.Parameters.AddWithValue("@ExecutionDate", obj.ExecutionDate);
					cmd.Parameters.AddWithValue("@Description", obj.Description);
					cmd.Parameters.AddWithValue("@CardNumber", obj.CardNumber);
					cmd.Parameters.AddWithValue("@AccountNumber", obj.AccountNumber);
					cmd.Parameters.AddWithValue("@Amount", obj.Amount);
					value = await DataConnection.GetValue(cmd);
				}
				return await DataConnection.Result(value, obj);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<Deposit>> GetDeposits(int id)
		{
			try
			{
				List<Deposit> deposits = null;
				using(var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_ListTransaction_Deposit", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@ClientID", id);
					SqlDataReader sdr = await cmd.ExecuteReaderAsync();
					if (sdr.HasRows)
					{
						deposits = new List<Deposit>();
						while (await sdr.ReadAsync())
						{
							deposits.Add(GetObject(sdr));
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

		public async Task<List<Transfer>> GetTransfers(int id)
		{
			try
			{
				List<Transfer> deposits = null;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_ListTransaction_Transfer", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@ClientID", id);
					SqlDataReader sdr = await cmd.ExecuteReaderAsync();
					if (sdr.HasRows)
					{
						deposits = new List<Transfer>();
						while (await sdr.ReadAsync())
						{
							deposits.Add(GetTransfer(sdr));
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

		public async Task<List<WithDrawal>> GetWithDrawals(int id)
		{
			try
			{
				List<WithDrawal> withDrawals = null;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_ListTransaction_Drawals", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@ClientID", id);
					SqlDataReader sdr = await cmd.ExecuteReaderAsync();
					if (sdr.HasRows)
					{
						withDrawals = new List<WithDrawal>();
						while (await sdr.ReadAsync())
						{
							withDrawals.Add(GetDrawal(sdr));
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

		public Deposit GetObject(SqlDataReader sdr)
		{
			return new Deposit(sdr["FullName"].ToString(), sdr["ClientName"].ToString(), Convert.ToDateTime(sdr["ExecutionDate"]), sdr["CardNumber"].ToString(),
				sdr["AccountNumber"].ToString(), sdr["Description"].ToString(), double.Parse(sdr["Amount"].ToString()));
		}

		private Transfer GetTransfer(SqlDataReader sdr)
		{
			return new Transfer(sdr["FullName"].ToString(), sdr["ClientName"].ToString(), Convert.ToDateTime(sdr["ExecutionDate"]), sdr["CardNumber"].ToString(),
				sdr["AccountNumber"].ToString(), sdr["ToAccountNumber"].ToString() ,sdr["Description"].ToString(), double.Parse(sdr["Amount"].ToString()));
		}

		private WithDrawal GetDrawal(SqlDataReader sdr)
		{
			return new WithDrawal(sdr["FullName"].ToString(), sdr["ClientName"].ToString(), Convert.ToDateTime(sdr["ExecutionDate"]), sdr["CardNumber"].ToString(),
				   sdr["AccountNumber"].ToString(), sdr["Description"].ToString(), double.Parse(sdr["Amount"].ToString()));
		}

		public async Task<PayCredit> PayCredit(PayCredit payCredit)
		{
			try
			{
				int value = 0;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_PayCredit", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@FullName", payCredit.FullName);
					cmd.Parameters.AddWithValue("@ClientID", payCredit.ClientID);
					cmd.Parameters.AddWithValue("@CardNumber", payCredit.CardNumber);
					cmd.Parameters.AddWithValue("@AccountNumber", payCredit.AccountNumber);
					cmd.Parameters.AddWithValue("@CreditNumber", payCredit.CreditNumber);
					cmd.Parameters.AddWithValue("@Amount", payCredit.Amount);
					cmd.Parameters.AddWithValue("@Description", payCredit.Description);
					value = await DataConnection.GetValue(cmd);
				}
				return await DataConnection.Result(value, payCredit);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<PayCredit>> PayCredits(string email)
		{
			try
			{
				List<PayCredit> payCredits = null;
				using (var con = await DataConnection.Connection())
				{
					var cmd = DataConnection.Command(con, "sp_GetPayCredits", CommandType.StoredProcedure);
					cmd.Parameters.AddWithValue("@Email", email);
					SqlDataReader sdr = await cmd.ExecuteReaderAsync();
					if (sdr.HasRows)
					{
						payCredits = new List<PayCredit>();
						while (await sdr.ReadAsync())
						{
							payCredits.Add(new PayCredit(sdr["FullName"].ToString(), sdr["ClientName"].ToString(), Convert.ToDateTime(sdr["ExecutionDate"].ToString()),
								sdr["CardNumber"].ToString(), sdr["AccountNumber"].ToString(), sdr["Description"].ToString(), double.Parse(sdr["Amount"].ToString()), sdr["CreditNumber"].ToString()));
						}
					}
				}
				return payCredits;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}

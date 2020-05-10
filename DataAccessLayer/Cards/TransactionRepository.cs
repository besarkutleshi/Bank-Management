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
    public class TransactionRepository : IInsert<Deposit>,IInsert<Transfer>,IInsert<WithDrawal>
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
					cmd.Parameters.AddWithValue("@Amountr", obj.Amount);
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
					cmd.Parameters.AddWithValue("@Amountr", obj.Amount);
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
					cmd.Parameters.AddWithValue("@Amountr", obj.Amount);
					value = await DataConnection.GetValue(cmd);
				}
				return await DataConnection.Result(value, obj);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

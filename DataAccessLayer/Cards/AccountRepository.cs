using EntityLayer.Accounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Cards
{
    public class AccountRepository
    {
        ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }


        public async Task<ActionResult<SavingAccounts>> Insert(SavingAccounts obj)
        {
            try
            {
                await _context.SavingAccounts.AddAsync(obj);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ActionResult<SavingAccounts>> DeleteSavingAccount(int id)
        {
            try
            {
                Accounts accounts = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == id);
                SavingAccounts savingAccounts = await _context.SavingAccounts.FirstOrDefaultAsync(acc => acc.Account.Id == id);
                _context.Accounts.Remove(accounts);
                _context.SavingAccounts.Remove(savingAccounts);
                if (await _context.SaveChangesAsync() > 0)
                    return savingAccounts;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<SavingAccounts>> ReadSaving()
        {
            try
            {
                await _context.Persons.ToListAsync();
                await _context.Clients.ToListAsync();
                await _context.Accounts.ToListAsync();
                await _context.Accounts.ToListAsync();
                return await _context.SavingAccounts.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<SavingAccounts>> ReadSaving(string email)
        {
            try
            {
                List<SavingAccounts> checkingAccounts = null;
                using (var con = await DataConnection.Connection())
                {
                    var cmd = DataConnection.Command(con, "sp_GetSavingAccount_ByEmail", CommandType.StoredProcedure);
                    cmd.Parameters.AddWithValue("@Email", email);
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        checkingAccounts = new List<SavingAccounts>();
                        while (await sdr.ReadAsync())
                        {
                            SavingAccounts obj = new SavingAccounts();
                            obj.AccountId = int.Parse(sdr["ID"].ToString());
                            obj.Account.Id = int.Parse(sdr["ID"].ToString());
                            obj.Account.AccountNumber = sdr["AccountNumber"].ToString();
                            obj.Account.CardNumber = sdr["CardNumber"].ToString();
                            checkingAccounts.Add(obj);
                        }
                    }
                    return checkingAccounts;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<ActionResult<SavingAccounts>> Update(SavingAccounts obj)
        {
            try
            {
                var account = _context.Accounts.Attach(obj.Account);
                account.State = EntityState.Modified;
                var savingaccount = _context.SavingAccounts.Attach(obj);
                savingaccount.State = EntityState.Modified;
                if (await _context.SaveChangesAsync() > 0)
                    return obj;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ActionResult<CheckingAccounts>> Insert(CheckingAccounts obj)
        {
            try
            {
                await _context.CheckingAccounts.AddAsync(obj);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<List<CheckingAccounts>> ReadChecking()
        {
            try
            {
                await _context.Persons.ToListAsync();
                await _context.Clients.ToListAsync();
                await _context.Accounts.ToListAsync();
                return await _context.CheckingAccounts.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<CheckingAccounts>> ReadChecking(string email)
        {
            try
            {
                List<CheckingAccounts> checkingAccounts = null;
                using (var con = await DataConnection.Connection())
                {
                    var cmd = DataConnection.Command(con, "sp_GetCheckingAccount_ByEmail", CommandType.StoredProcedure);
                    cmd.Parameters.AddWithValue("@Email", email);
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        checkingAccounts = new List<CheckingAccounts>();
                        while(await sdr.ReadAsync())
                        {
                            CheckingAccounts obj = new CheckingAccounts();
                            obj.AccountId = int.Parse(sdr["ID"].ToString());
                            obj.Account.Id = int.Parse(sdr["ID"].ToString());
                            obj.Account.AccountNumber = sdr["AccountNumber"].ToString();
                            obj.Account.CardNumber = sdr["CardNumber"].ToString();
                            checkingAccounts.Add(obj);
                        }
                    }
                    return checkingAccounts;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<ActionResult<CheckingAccounts>> Update(CheckingAccounts obj)
        {
            try
            {
                var account = _context.Accounts.Attach(obj.Account);
                account.State = EntityState.Modified;
                var checkinggaccount = _context.CheckingAccounts.Attach(obj);
                checkinggaccount.State = EntityState.Modified;
                if (await _context.SaveChangesAsync() > 0)
                    return obj;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Accounts>> GetAccounts()
        {
            await _context.Persons.ToListAsync();
            await _context.Clients.ToListAsync();
            await _context.Accounts.ToListAsync();
            return await _context.Accounts.ToListAsync();
        }

        public Accounts GetAccount(int id)
        {
            _context.Persons.FirstOrDefault(p => p.Id ==id);
            _context.Clients.FirstOrDefault(p => p.PersonId == id);
            return _context.Accounts.FirstOrDefault(acc => acc.ClientId == id);
        }

        public Accounts GetAccount(string accountnumber)
        {
            return _context.Accounts.FirstOrDefault(acc => acc.AccountNumber == accountnumber);
        }

        public decimal GetBalance(int clientid)
        {
            Accounts acc = _context.Accounts.FirstOrDefault(acc => acc.ClientId == clientid);
            return (decimal)acc.Balance;
        }

        public async Task<CheckingAccounts> CheckingAccountsDetails(string id)
        {
            Accounts acc = await _context.Accounts.FirstOrDefaultAsync(acc => acc.AccountNumber == id);
            EntityLayer.Persons.Persons person = await _context.Persons.FirstOrDefaultAsync(pr => pr.Id == acc.ClientId);
            CheckingAccounts checking = await _context.CheckingAccounts.FirstOrDefaultAsync(ch => ch.Account.AccountNumber == id);
            acc.Client = person;
            checking.Account = acc;
            return checking;
        }

        public async Task<SavingAccounts> SavingAccountsDetails(string id)
        {
            Accounts acc = await _context.Accounts.FirstOrDefaultAsync(acc => acc.AccountNumber == id);
            EntityLayer.Persons.Persons person = await _context.Persons.FirstOrDefaultAsync(pr => pr.Id == acc.ClientId);
            SavingAccounts checking = await _context.SavingAccounts.FirstOrDefaultAsync(ch => ch.Account.AccountNumber == id);
            acc.Client = person;
            checking.Account = acc;
            return checking;
            
        }
    }
}

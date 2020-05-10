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

        public async Task<SavingAccounts> ReadSaving(int id)
        {
            try
            {
                Accounts acc = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == id);
                SavingAccounts sacc = await _context.SavingAccounts.FirstOrDefaultAsync(acc => acc.Account.Id == id);
                return sacc;
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

        public async Task<CheckingAccounts> ReadChecking(int id)
        {
            try
            {
                Accounts acc = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == id);
                CheckingAccounts chacc = await _context.CheckingAccounts.FirstOrDefaultAsync(acc => acc.Account.Id == id);
                return chacc;
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
    }
}

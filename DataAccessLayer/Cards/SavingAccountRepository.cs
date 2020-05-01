using DataAccessLayer.Interface;
using EntityLayer.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Cards
{
    public class SavingAccountRepository : ICrud<SavingAccounts>
    {
        ApplicationDbContext _context;
        public SavingAccountRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<ActionResult<SavingAccounts>> Delete(int id)
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

        public async Task<ActionResult<SavingAccounts>> Insert(SavingAccounts obj)
        {
            try
            {
                _context.SavingAccounts.Add(obj);
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

        public async Task<IEnumerable<SavingAccounts>> Read()
        {
            try
            {
                await _context.Accounts.ToListAsync();
                return await _context.SavingAccounts.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SavingAccounts> Read(int id)
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

        public Task<SavingAccounts> Read(string name)
        {
            throw new NotImplementedException();
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
    }
}

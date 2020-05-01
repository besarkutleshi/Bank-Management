using DataAccessLayer.Interface;
using EntityLayer.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Cards
{
    public class CheckingAccountRepository : ICrud<CheckingAccounts>
    {
        ApplicationDbContext _context;
        public CheckingAccountRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<ActionResult<CheckingAccounts>> Delete(int id)
        {
            try
            {
                Accounts accounts = await _context.Accounts.FirstOrDefaultAsync(acc => acc.Id == id);
                CheckingAccounts checkingAccounts  = await _context.CheckingAccounts.FirstOrDefaultAsync(acc => acc.Account.Id == id);
                _context.Accounts.Remove(accounts);
                _context.CheckingAccounts.Remove(checkingAccounts);
                if (await _context.SaveChangesAsync() > 0)
                    return checkingAccounts;
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
                _context.CheckingAccounts.Add(obj);
                if (await _context.SaveChangesAsync() > 0)
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

        public async Task<IEnumerable<CheckingAccounts>> Read()
        {
            try
            {
                await _context.Accounts.ToListAsync();
                return await _context.CheckingAccounts.ToListAsync();   
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CheckingAccounts> Read(int id)
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

        public Task<CheckingAccounts> Read(string name)
        {
            throw new NotImplementedException();
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
    }
}

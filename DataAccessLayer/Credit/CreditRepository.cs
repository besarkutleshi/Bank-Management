using EntityLayer.Credits;
using EntityLayer.Persons;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Credit
{
    public class CreditRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Credits> InsertCredit(Credits obj)
        {
            try
            {
                _context.Credits.Add(obj);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<int> DeleteCredit(int id)
        {
            try
            {
                Credits obj = await _context.Credits.FirstOrDefaultAsync(c => c.Id == id);
                _context.Credits.Remove(obj);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return id;
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Credits> UpdateCredit(Credits obj)
        {
            try
            {
                //var client = _context.Persons.Attach(obj.Client);
                //client.State = EntityState.Modified;
                var credit = _context.Credits.Attach(obj);
                credit.State = EntityState.Modified;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Credits>> GetCredits()
        {
            try
            {
                await _context.Persons.ToListAsync();
                return await _context.Credits.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Credits> GetCredit(int id)
        {
            try
            {
                Credits credits = await _context.Credits.FirstOrDefaultAsync(c => c.Id == id);
                EntityLayer.Persons.Persons persons = await _context.Persons.FirstOrDefaultAsync(p => p.Id == credits.Id);
                credits.Client = persons;
                return credits;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Credits> GetCredit(string creditnumber)
        {
            try
            {
                Credits credits = await _context.Credits.FirstOrDefaultAsync(c => c.CreditNumber == creditnumber);
                EntityLayer.Persons.Persons persons = await _context.Persons.FirstOrDefaultAsync(p => p.Id == credits.ClientId);
                credits.Client = persons;
                return credits;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Credits>> MyCredits(string email)
        {
            try
            {
                List<Credits> credits = null;
                using (var con = await DataConnection.Connection())
                {
                    var cmd = DataConnection.Command(con, "sp_GetCredits_ByEmail", CommandType.StoredProcedure);
                    cmd.Parameters.AddWithValue("@Email", email);
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        credits = new List<Credits>();
                        while (await sdr.ReadAsync())
                        {
                            Credits obj = new Credits();
                            obj.Id = int.Parse(sdr["ID"].ToString());
                            obj.CreditNumber = sdr["CreditNumber"].ToString();
                            credits.Add(obj);
                        }
                    }
                }
                return credits;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

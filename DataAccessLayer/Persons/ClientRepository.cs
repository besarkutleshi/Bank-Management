using DataAccessLayer.Interface;
using EntityLayer.Persons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Persons
{
    public class ClientRepository : ICrud<Clients>
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<Clients>> Delete(int id)
        {
            try
            {
                EntityLayer.Persons.Persons p = _context.Persons.Where(p => p.Id == id).FirstOrDefault();
                Clients cls = _context.Clients.Where(cls => cls.PersonId == id).FirstOrDefault();
                _context.Persons.Remove(p);
                _context.Clients.Remove(cls);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return cls;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ActionResult<Clients>> Insert(Clients obj)
        {
            try
            {
                _context.Clients.Add(obj);
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

        public async Task<IEnumerable<Clients>> Read()
        {
            try
            {
                await _context.Persons.ToListAsync();
                return await _context.Clients.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Clients> Read(int id)
        {
            try
            {
                EntityLayer.Persons.Persons p = await _context.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();
                Clients cls = await _context.Clients.Where(cls => cls.PersonId == id).FirstOrDefaultAsync();
                return cls;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Clients> Read(string name)
        {
            try
            {
                EntityLayer.Persons.Persons p = await _context.Persons.Where(p => p.Name == name).FirstOrDefaultAsync();
                Clients cls = await _context.Clients.Where(cls => cls.Person.Name == name).FirstOrDefaultAsync();
                return cls;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ActionResult<Clients>> Update(Clients obj)
        {
            try
            {
                var person = _context.Persons.Attach(obj.Person);
                person.State = EntityState.Modified;
                var client = _context.Clients.Attach(obj);
                client.State = EntityState.Modified;
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
    }
}

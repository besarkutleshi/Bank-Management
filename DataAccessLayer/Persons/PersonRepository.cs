using EntityLayer.Persons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Persons
{
    public class PersonRepository
    {
        public readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EntityLayer.Persons.Persons>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<EntityLayer.Persons.Persons> GetPersons(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

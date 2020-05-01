using DataAccessLayer.Interface;
using EntityLayer.Persons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Clients>> Insert(Clients obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Clients>> Read()
        {
            throw new NotImplementedException();
        }

        public async Task<Clients> Read(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Clients> Read(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Clients>> Update(Clients obj)
        {
            throw new NotImplementedException();
        }
    }
}

using DataAccessLayer.Interface;
using EntityLayer.Accounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Cards
{
    public class AccountRepository : ICrud<Accounts>
    {
        public Task<ActionResult<Accounts>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Accounts>> Insert(Accounts obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Accounts>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<Accounts> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Accounts> Read(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Accounts>> Update(Accounts obj)
        {
            throw new NotImplementedException();
        }
    }
}

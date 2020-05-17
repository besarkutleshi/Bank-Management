using System;
using System.Collections.Generic;

namespace EntityLayer.Accounts
{
    public partial class Accounts
    {
        public Accounts()
        {
            //Client = new Persons.Persons();
        }
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public decimal? Balance { get; set; }
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public bool? Activ { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual Persons.Persons Client { get; set; }
    }
}

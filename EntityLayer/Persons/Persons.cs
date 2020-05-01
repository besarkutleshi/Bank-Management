using System;
using System.Collections.Generic;
using EntityLayer.Accounts;
using EntityLayer.Entity;

namespace EntityLayer.Persons
{
    public partial class Persons
    {
        public Persons()
        {
            Accounts = new HashSet<Accounts.Accounts>();
            Credits = new HashSet<Credits.Credits>();
            Transactions = new HashSet<Transactions>();
        }

        public int Id { get; set; }
        public string PersonalNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? StreetNr { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string NrTel { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Accounts.Accounts> Accounts { get; set; }
        public virtual ICollection<Credits.Credits> Credits { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}

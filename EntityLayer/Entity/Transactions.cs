using System;
using System.Collections.Generic;

namespace EntityLayer.Entity
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal? Sum { get; set; }
        public int? ClientId { get; set; }
        public string AccountNumber { get; set; }
        public string ToAccountNumber { get; set; }
        public DateTime? Date { get; set; }

        public virtual Persons.Persons Client { get; set; }
    }
}

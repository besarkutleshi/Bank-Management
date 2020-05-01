using System;
using System.Collections.Generic;

namespace EntityLayer.Credits
{
    public partial class Credits
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public decimal? Balance { get; set; }

        public virtual Persons.Persons Client { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EntityLayer.Persons
{
    public partial class Clients
    {
        public int? PersonId { get; set; }
        public bool? IsPremium { get; set; }

        public virtual Persons Person { get; set; }
    }
}

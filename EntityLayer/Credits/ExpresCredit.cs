using System;
using System.Collections.Generic;

namespace EntityLayer.Credits
{
    public partial class ExpresCredit : Credits
    {
        public int? CreditId { get; set; }
        public decimal? Interes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Credits Credit { get; set; }
    }
}

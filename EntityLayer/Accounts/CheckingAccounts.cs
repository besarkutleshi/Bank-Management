using System;
using System.Collections.Generic;

namespace EntityLayer.Accounts
{
    public partial class CheckingAccounts
    {
        public int? AccountId { get; set; }
        public decimal? Interes { get; set; }

        public virtual Accounts Account { get; set; }
    }
}

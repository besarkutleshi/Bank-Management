using System;
using System.Collections.Generic;

namespace EntityLayer.Accounts
{
    public partial class SavingAccounts
    {
        public SavingAccounts()
        {
            //Account = new Accounts();
        }
        public int? AccountId { get; set; }
        public decimal? Interes { get; set; }
        public decimal MaxTotal { get; set; }
        public virtual Accounts Account { get; set; }
    }
}

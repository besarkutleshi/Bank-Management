using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Accounts
{
    public partial class SavingAccounts
    {
        public SavingAccounts()
        {
            //Account = new Accounts();
        }
        public int? AccountId { get; set; }
        [Required]
        public decimal? Interes { get; set; }
        [Required]
        public decimal MaxTotal { get; set; }
        public virtual Accounts Account { get; set; }
    }
}

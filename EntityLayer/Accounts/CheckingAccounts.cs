using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Accounts
{
    public partial class CheckingAccounts
    {
        public CheckingAccounts()
        {
           // Account = new Accounts();
        }
        public int? AccountId { get; set; }
        [Required]
        public decimal? Interes { get; set; }

        public virtual Accounts Account { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [CardNumberAttribute(16)]
        public string CardNumber { get; set; }
        [Required]
        [CardNumberAttribute(16)]
        public string AccountNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool? Activ { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual Persons.Persons Client { get; set; }
    }
}

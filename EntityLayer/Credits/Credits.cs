using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Credits
{
    public partial class Credits
    {
        public int Id { get; set; }
        [Required]
        [CardNumberAttribute(16)]
        public string CreditNumber { get; set; }
        [Required]
        public int ClientId { get; set; }
        public decimal? Balance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? Interes { get; set; }
        public virtual Persons.Persons Client { get; set; }
    }
}

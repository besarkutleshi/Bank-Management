using EntityLayer.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Transactions
{
    public class PayCredit : Transaction, IImplement
    {
        [Required]
        [CardNumber(16)]
        public string AccountNumber { get; set; }
        [Required]
        [CardNumber(16)]
        public string CardNumber { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        [CardNumber(16)]
        public string CreditNumber { get; set; }

        public PayCredit(string fullname, string name, DateTime date, string cardnumber, string accountnumber, string description, double amount,string creditnumber)
        {
            this.FullName = fullname;
            Client = new Persons.Persons();
            Client.Name = name;
            ExecutionDate = date;
            CardNumber = cardnumber;
            AccountNumber = accountnumber;
            Description = description;
            Amount = amount;
            CreditNumber = creditnumber;
        }
    }
}

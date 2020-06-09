using EntityLayer.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Transactions
{
    public class Transfer : Transaction, IImplement
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
        public string ToAccountNumber { get; set; }
        public Transfer()
        {

        }
        public Transfer(string fullname, string name, DateTime date, string cardnumber, string accountnumber,
            string toaccount, string description, double amount)
        {
            this.FullName = fullname;
            Client = new Persons.Persons();
            Client.Name = name;
            ExecutionDate = date;
            CardNumber = cardnumber;
            AccountNumber = accountnumber;
            ToAccountNumber = toaccount;
            Description = description;
            Amount = amount;
        }
    }
}

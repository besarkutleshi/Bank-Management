using EntityLayer.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Transactions
{
    public class PayCredit : Transaction, IImplement
    {
        public string AccountNumber { get; set; }
        public string CardNumber { get; set; }
        public double Amount { get; set; }
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

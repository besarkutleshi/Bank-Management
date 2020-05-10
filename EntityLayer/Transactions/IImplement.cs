using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Transactions
{
    public interface IImplement
    {
        public string AccountNumber { get; set; }
        public string CardNumber { get; set; }
        public double Amount { get; set; }
    }
}

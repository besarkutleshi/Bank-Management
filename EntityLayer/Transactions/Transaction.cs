﻿using EntityLayer.Personeli;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Accounts
{
    public abstract class Transaction
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string Description { get; set; }
    }
}

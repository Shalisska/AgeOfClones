using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Transactions
{
    public class TransactionPart
    {
        public decimal Value { get; set; }
        public decimal PricePerOne { get; set; }
        public decimal PriceTotal { get; set; }
    }
}

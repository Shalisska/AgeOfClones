using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeOfClones.Models
{
    public class TransactionInput
    {
        public int CurrencyId { get; set; }
        public int CorrespondingId { get; set; }

        public decimal Value { get; set; }
    }
}

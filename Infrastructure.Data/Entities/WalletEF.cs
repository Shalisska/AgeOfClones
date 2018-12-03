using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    [Table("Wallets")]
    public class WalletEF
    {
        public WalletEF() { }

        public WalletEF(
            decimal value,
            int accountId,
            int currencyId)
        {
            Value = value;
            AccountId = accountId;
            CurrencyId = currencyId;
        }

        public decimal Value { get; set; }

        public int AccountId { get; set; }
        public AccountEF Account { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}

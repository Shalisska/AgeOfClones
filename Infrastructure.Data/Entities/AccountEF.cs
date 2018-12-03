using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities
{
    [Table("Accounts")]
    public class AccountEF
    {
        public AccountEF() { }

        public AccountEF(
            int id,
            string name,
            int profileId,
            Profile profile)
        {
            Id = id;
            Name = name;
            ProfileId = profileId;
            Profile = profile;
        }

        public AccountEF(
            int id,
            string name,
            int profileId,
            Profile profile,
            ICollection<WalletEF> wallets) : this(id, name, profileId, profile)
        {
            Wallets = wallets;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public ICollection<WalletEF> Wallets { get; set; }
    }
}

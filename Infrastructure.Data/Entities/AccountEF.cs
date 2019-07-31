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
            ProfileEF profile)
        {
            Id = id;
            Name = name;
            ProfileId = profileId;
            Profile = profile;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<CurrencyEF> Currencies { get; set; }
        public List<ResourceEF> Resources { get; set; }

        public int ProfileId { get; set; }
        public ProfileEF Profile { get; set; }
    }
}

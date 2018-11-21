using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities
{
    public class Profile
    {
        public Profile() { }

        public Profile(int id, string name, ICollection<Account> accounts)
        {
            Id = id;
            Name = name;
            Accounts = accounts;
        }

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}

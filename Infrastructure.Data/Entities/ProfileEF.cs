using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities
{
    [Table("Profiles")]
    public class ProfileEF
    {
        public ProfileEF() { }

        public ProfileEF(int id, string name, ICollection<AccountEF> accounts)
        {
            Id = id;
            Name = name;
            Accounts = accounts;
        }

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AccountEF> Accounts { get; set; }
    }
}

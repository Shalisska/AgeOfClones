using System.Collections.Generic;

namespace Application.Models.AccountModel
{
    public class ProfileModel
    {
        public ProfileModel() { }

        public ProfileModel(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<AccountModel> Accounts { get; set; }
    }
}

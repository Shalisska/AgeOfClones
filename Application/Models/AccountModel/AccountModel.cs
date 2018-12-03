using Domain.GameModule.Entities.Account;
using System.Collections.Generic;

namespace Application.Models.AccountModel
{
    public class AccountModel : Account
    {
        public AccountModel() { }

        public AccountModel(
            int id,
            string name,
            IEnumerable<WalletModel> currencies,
            int profileId,
            ProfileModel profile)
        {
            Id = id;
            Name = name;
            Currencies = currencies;
            ProfileId = profileId;
            Profile = profile;
        }

        public int ProfileId { get; set; }
        public ProfileModel Profile { get; set; }
    }
}

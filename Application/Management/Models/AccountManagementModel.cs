namespace Application.Management.Models
{
    public class AccountManagementModel
    {
        public AccountManagementModel() { }

        public AccountManagementModel(
            int id,
            string name,
            int profileId,
            ProfileManagementModel profile)
        {
            Id = id;
            Name = name;
            ProfileId = profileId;
            Profile = profile;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int ProfileId { get; set; }
        public ProfileManagementModel Profile { get; set; }
    }
}

namespace Infrastructure.Data.Entities
{
    public class Account
    {
        public Account() { }

        public Account(
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

        public int Id { get; set; }
        public string Name { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}

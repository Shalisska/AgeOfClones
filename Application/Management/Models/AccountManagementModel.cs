using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Management.Models
{
    public class AccountManagementModel
    {
        public AccountManagementModel() { }

        public AccountManagementModel(
            int id,
            string name,
            int profileId)
        {
            Id = id;
            Name = name;
            ProfileId = profileId;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int ProfileId { get; set; }
    }
}

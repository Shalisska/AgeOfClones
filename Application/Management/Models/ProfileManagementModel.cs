using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Management.Models
{
    public class ProfileManagementModel
    {
        public ProfileManagementModel() { }

        public ProfileManagementModel(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<AccountManagementModel> Accounts { get; set; }
    }
}

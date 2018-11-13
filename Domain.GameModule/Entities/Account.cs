using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GameModule.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProfileId { get; set; }
    }
}

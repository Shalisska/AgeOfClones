using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    [Table("Clones")]
    public class CloneEF
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// Работоспособность
        /// </summary>
        public decimal Performance { get; set; }

        public int AccountId { get; set; }

        public AccountEF Account { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GameModule.Entities
{
    public class Clone
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
    }
}

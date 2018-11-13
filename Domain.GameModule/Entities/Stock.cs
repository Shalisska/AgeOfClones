using System.Collections.Generic;

namespace Domain.GameModule.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}

using System.Collections.Generic;

namespace Infrastructure.Data.Entities
{
    public class Stock
    {
        public Stock() { }

        public Stock(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}

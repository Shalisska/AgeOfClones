using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities
{
    [Table("Stocks")]
    public class StockEF
    {
        public StockEF() { }

        public StockEF(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ResourceEF> Resources { get; set; }
    }
}

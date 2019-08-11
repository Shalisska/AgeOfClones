using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    [Table("Operations")]
    public class OperationEF
    {
        public int Id { get; set; }
        public int OperationDirection { get; set; }
        public int ParentId { get; set; }
        public int ParticipantId { get; set; }
        public int GoodsId { get; set; }
        public decimal Value { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfClosing { get; set; }
        public int OperationStatus { get; set; }
        public bool IsFullyUsed { get; set; }
    }
}

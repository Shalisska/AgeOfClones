using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GameModule.Entities.CommonItems
{
    public class Operation
    {
        public int Id { get; set; }
        public OperationDirection OperationDirection { get; set; }
        public int ParentId { get; set; }
        public int StorageId { get; set; }
        public int GoodsId { get; set; }
        public decimal Value { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfClosing { get; set; }
        public OperationStatus Status { get; set; }
        public bool IsFullyUsed { get; set; }

        public List<Operation> ChildOperations { get; set; }
    }
}

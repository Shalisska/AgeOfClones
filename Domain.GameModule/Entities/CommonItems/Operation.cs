using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GameModule.Entities.CommonItems
{
    public class Operation
    {
        public Operation() { }

        public Operation(
            int id,
            OperationDirection direction,
            int parentId,
            int storageId,
            int goodsId,
            decimal value,
            decimal price,
            DateTime dateOfCreation,
            DateTime dateOfClosing,
            OperationStatus status,
            bool isFullyUsed,
            List<Operation> childOperations)
        {
            Id = id;
            Direction = direction;
            ParentId = parentId;
            StorageId = storageId;
            GoodsId = goodsId;
            Value = value;
            Price = price;
            DateOfCreation = dateOfCreation;
            DateOfClosing = dateOfClosing;
            Status = status;
            IsFullyUsed = isFullyUsed;
            ChildOperations = childOperations;

            HasChildren = childOperations != null && childOperations.Count > 0;
        }

        public int Id { get; set; }
        public OperationDirection Direction { get; set; }
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

        public bool HasChildren { get; set; }
    }
}

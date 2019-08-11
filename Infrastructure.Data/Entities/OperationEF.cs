using Domain.GameModule.Entities.CommonItems;
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
        public OperationEF() { }

        public OperationEF(
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
            bool hasChildren)
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

            HasChildren = hasChildren;
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

        public ICollection<OperationEF> ChildOperations { get; set; }

        public bool HasChildren { get; set; }

        public Operation ConvertToDTO(List<OperationEF> operations)
        {
            var childs = operations?.Where(o => o.ParentId == Id);
            var childsDto = new List<Operation>();

            if (childs != null && childs.Count() > 0)
                childsDto.AddRange(childs.Select(ch => ch.ConvertToDTO(operations)));

            var dto = new Operation(
                      Id,
                      Direction,
                      ParentId,
                      StorageId,
                      GoodsId,
                      Value,
                      Price,
                      DateOfCreation,
                      DateOfClosing,
                      Status,
                      IsFullyUsed,
                      childsDto);

            return dto;
        }
    }
}

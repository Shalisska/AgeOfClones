using Domain.GameModule.Entities.CommonItems;
using System.Collections.Generic;

namespace Domain.GameModule.Entities.TradeBlockItems
{
    public class Stock : IOperationParticipant
    {
        public int ParticipantId { get; set; }
        public int StorageId { get; set; }
        public BlockType BlockType { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}

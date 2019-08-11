using Domain.GameModule.Entities.CommonItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GameModule.Entities.TradeBlockItems
{
    public class TradeBlock : IOperationParticipant
    {
        public TradeBlock(
            int storageId)
        {
            BlockType = BlockType.Trade;
            ParticipantId = (int)BlockType;
            StorageId = storageId;
        }

        public int ParticipantId { get; set; }
        public int StorageId { get; set; }
        public BlockType BlockType { get; set; }

        public List<Stock> Stocks { get; set; }
    }
}

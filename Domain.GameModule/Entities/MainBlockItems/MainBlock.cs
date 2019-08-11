using Domain.GameModule.Entities.CommonItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GameModule.Entities.MainBlockItems
{
    public class MainBlock : IOperationParticipant
    {
        public MainBlock(
            Account account)
        {
            Account = account;
            ParticipantId = Account.Id;
            StorageId = Account.StorageId;
            BlockType = BlockType.Main;
        }

        public int ParticipantId { get; set; }
        public int StorageId { get; set; }

        public BlockType BlockType { get; set; }

        public Account Account { get; set; }
    }
}

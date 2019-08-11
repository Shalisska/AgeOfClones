using Domain.GameModule.Entities.CommonItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    [Table("StorageIdentities")]
    public class StorageIdentityEF
    {
        public StorageIdentityEF() { }

        public StorageIdentityEF(
            BlockType blockType,
            ParticipantType participantType,
            int participantId)
        {
            BlockType = blockType;
            ParticipantType = participantType;
            ParticipantId = participantId;
        }

        public int Id { get; set; }
        public BlockType BlockType { get; set; }
        public ParticipantType ParticipantType { get; set; }
        public int ParticipantId { get; set; }
    }
}

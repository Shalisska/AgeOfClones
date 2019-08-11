using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GameModule.Entities.CommonItems
{
    public interface IOperationParticipant
    {
        int ParticipantId { get; set; }
        int StorageId { get; set; }
    }
}

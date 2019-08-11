using Domain.GameModule.Entities.CommonItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Repositories
{
    public interface IOperationRepository
    {
        int GetStorageId(BlockType blockType, ParticipantType participantType, int participantId);
        int CreateStorageId(BlockType blockType, ParticipantType participantType, int participantId);
        void CreateOperation(Operation operation);
        List<Operation> GetOperations();
        List<Operation> GetOperations(Func<Operation, bool> func);
    }
}

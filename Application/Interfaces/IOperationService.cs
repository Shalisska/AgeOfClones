using Domain.GameModule.Entities.CommonItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOperationService
    {
        List<Operation> GetOperations();
        Operation CreateOperation(
            OperationDirection operationDirection,
            int storageId,
            int goodsId,
            decimal value,
            decimal price,
            DateTime date);

        void ConfirmOperation(Operation operation);
        int GetStorageId(BlockType blockType, ParticipantType participantType, int participantId);
    }
}

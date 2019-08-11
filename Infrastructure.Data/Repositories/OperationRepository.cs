using Application.Data.Repositories;
using Domain.GameModule.Entities.CommonItems;
using Infrastructure.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        //public OperationRepository(ClonesContextEF context) : base(context)
        //{
        //}

        public List<Operation> GetOperations()
        {
            throw new NotImplementedException();
        }

        public List<Operation> GetOperations(Func<Operation, bool> func)
        {
            throw new NotImplementedException();
        }

        public void CreateOperation(Operation operation)
        {
            throw new NotImplementedException();
        }

        public int CreateStorageId(BlockType blockType, ParticipantType participantType, int participantId)
        {
            throw new NotImplementedException();
        }

        public int GetStorageId(BlockType blockType, ParticipantType participantType, int participantId)
        {
            throw new NotImplementedException();
        }
    }
}

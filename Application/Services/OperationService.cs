using Application.Data.Repositories;
using Application.Interfaces;
using Application.Models;
using Domain.GameModule.Entities.CommonItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OperationService : IOperationService
    {
        IOperationRepository _operationRepository;

        public OperationService(
            IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public Operation CreateOperation(
            OperationDirection operationDirection,
            int storageId,
            int goodsId,
            decimal value,
            decimal price,
            DateTime date)
        {
            var operation = new Operation
            {
                Direction = operationDirection,
                StorageId = storageId,
                GoodsId = goodsId,
                Value = value,
                Price = price,
                DateOfCreation = date
            };

            return operation;
        }

        public void ConfirmOperation(Operation operation)
        {
            if (operation.ChildOperations == null || operation.ChildOperations.Count == 0)
                return;

            foreach (var child in operation.ChildOperations)
                child.Status = OperationStatus.Open;

            operation.Status = OperationStatus.Open;

            _operationRepository.CreateOperation(operation);
        }

        public int GetStorageId(BlockType blockType, ParticipantType participantType, int participantId)
        {
            var id = _operationRepository.GetStorageId(blockType, participantType, participantId);
            return id;
        }

        public int CreateStorageId(BlockType blockType, ParticipantType participantType, int participantId)
        {
            var id = _operationRepository.CreateStorageId(blockType, participantType, participantId);
            return id;
        }

        public List<Operation> GetOperations()
        {
            var operations = _operationRepository.GetOperations();
            return operations;
        }
    }
}

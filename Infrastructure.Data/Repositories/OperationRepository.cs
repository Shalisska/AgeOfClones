using Application.Data.Repositories;
using Domain.GameModule.Entities.CommonItems;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        ClonesContextEF _db;

        public OperationRepository(ClonesContextEF context)
        {
            _db = context;
        }

        public List<Operation> GetOperations()
        {
            var items = _db.Operations;

            if (items != null && items.Count() > 0)
            {
                var itemsDTO = items.Select(i => i.ConvertToDTO(items.ToList()));
                return itemsDTO.ToList();
            }

            return null;
        }

        public List<Operation> GetOperations(Func<Operation, bool> func)
        {
            throw new NotImplementedException();
        }

        public void CreateOperation(Operation operation)
        {
            AddOperationToContext(operation);

            _db.SaveChanges();
        }

        private void AddOperationToContext(Operation operation)
        {
            var item = new OperationEF(
                operation.Id,
                operation.Direction,
                operation.ParentId,
                operation.StorageId,
                operation.GoodsId,
                operation.Value,
                operation.Price,
                operation.DateOfCreation,
                operation.DateOfClosing,
                operation.Status,
                operation.IsFullyUsed,
                operation.HasChildren);

            _db.Operations.Add(item);

            if (operation.HasChildren)
                foreach (var child in operation.ChildOperations)
                    AddOperationToContext(child);
        }

        public int CreateStorageId(BlockType blockType, ParticipantType participantType, int participantId)
        {
            var item = new StorageIdentityEF(
                blockType,
                participantType,
                participantId);

            _db.StorageIdentities.Add(item);
            _db.SaveChanges();

            return item.Id;
        }

        private int CreateStorageId(StorageIdentityEF item)
        {
            return CreateStorageId(item.BlockType, item.ParticipantType, item.ParticipantId);
        }

        public int GetStorageId(BlockType blockType, ParticipantType participantType, int participantId)
        {
            var item = _db.StorageIdentities
                .FirstOrDefault(i => i.BlockType == blockType &&
                            i.ParticipantType == participantType &&
                            i.ParticipantId == participantId);

            if (item != null)
                return item.Id;

            return CreateStorageId(item);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

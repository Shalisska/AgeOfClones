//using Infrastructure.Data.EF;
//using Microsoft.EntityFrameworkCore;
//using System;

//namespace Infrastructure.Data.Repositories
//{
//    public abstract class DisposeRepository
//    {
//        ClonesContextEF _db;

//        public DisposeRepository(ClonesContextEF context)
//        {
//            _db = context;
//        }

//        #region IDisposable Support
//        private bool disposedValue = false; // To detect redundant calls

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!disposedValue)
//            {
//                if (disposing)
//                {
//                    _db.Dispose();
//                }

//                disposedValue = true;
//            }
//        }

//        // This code added to correctly implement the disposable pattern.
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        #endregion
//    }
//}

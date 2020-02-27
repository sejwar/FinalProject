using BlobApi.Entities;
using BlobApi.Modal;
using BlobApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobApi.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobDBContext _blobDBContext;
        public BlobService(BlobDBContext blobDBContext)
        {
            _blobDBContext = blobDBContext;
        }
        public Blob GetBlob(int id)
        {
            return _blobDBContext.blobs.FirstOrDefault<Blob>(x => x.id == id);
        }

        public List<Blob> GetBlobs()
        {
            return _blobDBContext.blobs.ToList<Blob>();
        }

        public void SaveBlob(Blob blob)
        {
            _blobDBContext.blobs.Add(blob);
            _blobDBContext.SaveChanges();
        }

        public bool DeleteBlob(int id)
        {
            Blob _blob = _blobDBContext.blobs.FirstOrDefault<Blob>(x => x.id == id);

            if (_blob != null)
            {
                _blobDBContext.blobs.Remove(_blob);
                _blobDBContext.SaveChanges();
            }
            else
                return false;

            return true;
        }

        public bool UpdateBlob(int id,Blob blob)
        {
            Blob _blob = _blobDBContext.blobs.FirstOrDefault<Blob>(x => x.id == id);

            if (_blob != null)
            {
                _blob.title = blob.title;
                _blob.description = blob.description;
                _blob.created_date = blob.created_date;
                _blobDBContext.Update<Blob>(_blob);
                _blobDBContext.SaveChanges();
            }
            else
                return false;
            return true;

        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _blobDBContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

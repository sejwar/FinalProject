using BlobApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobApi.Services.Interfaces
{
    public interface IBlobService : IDisposable
    {
        Blob GetBlob(int id);
        List<Blob> GetBlobs();
        void SaveBlob(Blob blob);
        bool DeleteBlob(int id);
        bool UpdateBlob(int id, Blob blob);
    }
}

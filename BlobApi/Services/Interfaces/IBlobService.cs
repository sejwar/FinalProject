using BlobApi.Entities;
using BlobApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobApi.Services.Interfaces
{
    public interface IBlobService : IDisposable
    {
        BlobVM GetBlob(int id);
        List<BlobVM> GetBlobs();
        void SaveBlob(Blob blob);
        bool DeleteBlob(int id);
        bool UpdateBlob(int id, Blob blob);
    }
}

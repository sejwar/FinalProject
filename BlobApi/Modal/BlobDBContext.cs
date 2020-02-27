using BlobApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobApi.Modal
{
    public class BlobDBContext : DbContext
    {
        public BlobDBContext(DbContextOptions<BlobDBContext> options) : base(options)
        {

        }
        public DbSet<Blob> blobs { get; set; }
    }
}

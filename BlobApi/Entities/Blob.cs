using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlobApi.Entities
{
    public class Blob
    {
        [Column("id")]
        public int id { get; set; }

        [Column("blob_head")]
        public string title { get; set; }

        [Column("blob_description")]
        public string description { get; set; }

        [Column("blob_created_date")]
        public DateTime created_date { get; set; }
    }
}

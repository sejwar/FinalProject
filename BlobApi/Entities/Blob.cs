using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlobApi.Entities
{
    public class Blob
    {
        [Column("id")]
        [Key]
        public int id { get; set; }

        [Column("blob_head")]
        public string title { get; set; }

        [Column("blob_description")]
        public string description { get; set; }

        [Column("blob_created_date")]
        public DateTime created_date { get; set; }

        [Column("blob_subject_id")]
        public int subject_id { get; set; }

        public virtual Subject subject { get; set; }

    }
}

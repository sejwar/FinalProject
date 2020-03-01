using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlobApi.Entities
{
    public class Subject
    {
        public Subject()
        {
            this.blobs = new HashSet<Blob>();
        }

        [Key]
        [Column("subject_id")]
        public int id { get; set; }

        [Column("subject_name")]
        public string name { get; set; }

        public virtual ICollection<Blob> blobs { get; set; }
    }
}

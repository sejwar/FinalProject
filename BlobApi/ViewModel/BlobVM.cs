using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobApi.ViewModel
{
    public class BlobVM
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string subject { get; set; }
        public DateTime created_date { get; set; }
    }
}

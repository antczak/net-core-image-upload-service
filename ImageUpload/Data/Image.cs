using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUpload.Data
{
    public class Image
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public DateTime Date { get; set; }
    }
}

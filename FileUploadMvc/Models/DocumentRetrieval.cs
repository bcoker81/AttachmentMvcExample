using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadMvc.Models
{
    public class DocumentRetrieval
    {
        public string FileName { get; set; }
        public string DocType { get; set; }
        public byte[] DocData { get; set; }
    }
}
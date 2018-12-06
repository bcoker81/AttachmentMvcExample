using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FileUploadMvc.Models
{
    [Table("Attachments")]
    public class AttachmentsModel
    {
        [Key]
        public int Id { get; set; }
        public string FK_Table { get; set; }
        public int FK_Id { get; set; }
        public string Uri { get; set; }
        public DateTime UploadDate { get; set; }
        public string Notes { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<DocumentModel> Documents { get; set; }
    }
}
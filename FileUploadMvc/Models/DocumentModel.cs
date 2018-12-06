using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FileUploadMvc.Models
{
    [Table("Documents")]
    public class DocumentModel
    {
        [Key]
        public int DocumentId { get; set; }
        public string DocumentData { get; set; }
        public DateTime AddedDate { get; set; }
        public int FK_Attachment_Id { get; set; }
        [ForeignKey("FK_Attachment_Id")]
        public AttachmentsModel Attachments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadMvc.Models
{
    public class ViewModel
    {
        public List<GrantModel> Grants { get; set; }
        public GrantModel Grant { get; set; }  
        public AttachmentsModel Attachment { get; set; }
        public List<AttachmentsModel> Attachments { get; set; }
        public ViewModel()
        {
            Grants = new List<GrantModel>();
            Grant = new GrantModel();
            Attachments = new List<AttachmentsModel>();
            Attachment = new AttachmentsModel();
        }
    }
}
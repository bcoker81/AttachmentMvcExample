using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FileUploadMvc.Models
{
    [Table("Grants")]
    public class GrantModel
    {
        public int Id { get; set; }
        [NotMapped]
        public int AttachmentCount { get; set; }
        public string GrantNumber { get; set; }
        public string GrantName { get; set; }
        public string Division { get; set; }

        public ICollection<ReportModel> ReportDates { get; set; }
    }
}
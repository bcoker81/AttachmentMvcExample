using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FileUploadMvc.Models
{
    [Table("Reports")]
    public class ReportModel
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportType { get; set; }
        public DateTime CreateDate { get; set; }
        public int FK_Grant_Id { get; set; }
        [ForeignKey("FK_Grant_Id")]
        public GrantModel Grant { get; set; }
    }
}
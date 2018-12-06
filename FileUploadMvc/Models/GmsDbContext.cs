using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FileUploadMvc.Models
{
    public class GmsDbContext : DbContext
    {
        public GmsDbContext() : base("name=GMSTest")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<GrantModel> Grants { get; set; }
        public DbSet<ReportModel> ReportDates { get; set; }
        public DbSet<AttachmentsModel> Attachments { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }
    }
}
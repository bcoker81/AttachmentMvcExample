namespace FileUploadMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialtablecreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_Table = c.String(),
                        FK_Id = c.Int(nullable: false),
                        Uri = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                        Notes = c.String(),
                        FileName = c.String(),
                        FileType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrantNumber = c.String(),
                        GrantName = c.String(),
                        Division = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        ReportDate = c.DateTime(nullable: false),
                        ReportType = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        FK_Grant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grants", t => t.FK_Grant_Id, cascadeDelete: true)
                .Index(t => t.FK_Grant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "FK_Grant_Id", "dbo.Grants");
            DropIndex("dbo.Reports", new[] { "FK_Grant_Id" });
            DropTable("dbo.Reports");
            DropTable("dbo.Grants");
            DropTable("dbo.Attachments");
        }
    }
}

namespace FileUploadMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDocumentTableForAttachmentsAndRelationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DocumentData = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        FK_Attachment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Attachments", t => t.FK_Attachment_Id, cascadeDelete: true)
                .Index(t => t.FK_Attachment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "FK_Attachment_Id", "dbo.Attachments");
            DropIndex("dbo.Documents", new[] { "FK_Attachment_Id" });
            DropTable("dbo.Documents");
        }
    }
}

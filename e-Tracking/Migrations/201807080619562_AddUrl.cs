namespace e_Tracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        ParentId = c.String(),
                        PrNumber = c.String(),
                    })
                .PrimaryKey(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}

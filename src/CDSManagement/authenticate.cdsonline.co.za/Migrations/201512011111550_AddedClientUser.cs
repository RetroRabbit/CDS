namespace authenticate.cdsonline.co.za.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ClientId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.RefreshTokens", "Subject", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RefreshTokens", "Subject", c => c.String(nullable: false, maxLength: 50));
            DropTable("dbo.ClientUsers");
        }
    }
}

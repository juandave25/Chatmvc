namespace Chatmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "IdUserSend", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "IdUserSend" });
            AlterColumn("dbo.Messages", "IdUserSend", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "IdUserSend", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "IdUserSend");
            AddForeignKey("dbo.Messages", "IdUserSend", "dbo.Users", "id");
        }
    }
}

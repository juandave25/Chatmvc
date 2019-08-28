namespace Chatmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "IdUserSend", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "IdUserSend");
            AddForeignKey("dbo.Messages", "IdUserSend", "dbo.Users", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "IdUserSend", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "IdUserSend" });
            AlterColumn("dbo.Messages", "IdUserSend", c => c.String());
        }
    }
}

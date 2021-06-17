namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_message_is_read : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageisRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageisRead");
        }
    }
}

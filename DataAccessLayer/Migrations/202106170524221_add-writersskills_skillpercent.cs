namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwritersskills_skillpercent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "SkillPercent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "SkillPercent");
        }
    }
}

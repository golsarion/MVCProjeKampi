namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwritersskills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WriterSkills",
                c => new
                    {
                        WriterID = c.Int(nullable: false),
                        SkillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WriterID, t.SkillID })
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
                .Index(t => t.WriterID)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        SkillInfo = c.String(),
                        SkillStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WriterSkills", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.WriterSkills", "SkillID", "dbo.Skills");
            DropIndex("dbo.WriterSkills", new[] { "SkillID" });
            DropIndex("dbo.WriterSkills", new[] { "WriterID" });
            DropTable("dbo.Skills");
            DropTable("dbo.WriterSkills");
        }
    }
}

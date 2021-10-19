namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_skill_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillCards",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 20),
                        UserDescription = c.String(maxLength: 50),
                        Skill1 = c.String(maxLength: 30),
                        SkillRatio1 = c.Int(nullable: false),
                        Skill2 = c.String(maxLength: 30),
                        SkillRatio2 = c.Int(nullable: false),
                        Skill3 = c.String(maxLength: 30),
                        SkillRatio3 = c.Int(nullable: false),
                        Skill4 = c.String(maxLength: 30),
                        SkillRatio4 = c.Int(nullable: false),
                        Skill5 = c.String(maxLength: 30),
                        SkillRatio5 = c.Int(nullable: false),
                        Skill6 = c.String(maxLength: 30),
                        SkillRatio6 = c.Int(nullable: false),
                        Skill7 = c.String(maxLength: 30),
                        SkillRatio7 = c.Int(nullable: false),
                        Skill8 = c.String(maxLength: 30),
                        SkillRatio8 = c.Int(nullable: false),
                        Skill9 = c.String(maxLength: 30),
                        SkillRatio9 = c.Int(nullable: false),
                        Skill10 = c.String(maxLength: 30),
                        SkillRatio10 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SkillCards");
        }
    }
}

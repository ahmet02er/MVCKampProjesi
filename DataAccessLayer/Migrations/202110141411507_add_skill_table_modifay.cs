namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_skill_table_modifay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SkillCards", "UserImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SkillCards", "UserImage");
        }
    }
}

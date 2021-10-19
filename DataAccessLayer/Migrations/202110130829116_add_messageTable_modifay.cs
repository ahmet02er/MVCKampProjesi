namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_messageTable_modifay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageRead");
            DropColumn("dbo.Messages", "MessageDraft");
        }
    }
}

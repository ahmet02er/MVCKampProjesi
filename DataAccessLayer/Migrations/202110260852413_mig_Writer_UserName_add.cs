namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Writer_UserName_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterUserName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterUserName");
        }
    }
}

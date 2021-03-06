namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Name");
        }
    }
}

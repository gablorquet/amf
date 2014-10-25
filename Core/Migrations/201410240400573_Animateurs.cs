namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Animateurs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Animateurs");
        }
    }
}

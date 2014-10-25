namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMajorUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Animateurs", newName: "Users");
            CreateTable(
                "dbo.Attacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weapon = c.Int(nullable: false),
                        Damage = c.Int(nullable: false),
                        Attribute = c.String(),
                        MagicWeapon = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        Skill_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .Index(t => t.Skill_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Target = c.String(),
                        Range = c.String(),
                        Duration = c.String(),
                        Limitation = c.String(),
                        IsSpell = c.Boolean(nullable: false),
                        IsPassive = c.Boolean(nullable: false),
                        IsPassive2 = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        Skill_Id = c.Int(),
                        Racial_Id = c.Int(),
                        RacialPreReq_Id = c.Int(),
                        Category_Id = c.Int(),
                        Category_Id1 = c.Int(),
                        Category_Id2 = c.Int(),
                        Character_Id = c.Int(),
                        Specialization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Races", t => t.Racial_Id)
                .ForeignKey("dbo.Categories", t => t.RacialPreReq_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id1)
                .ForeignKey("dbo.Categories", t => t.Category_Id2)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .ForeignKey("dbo.Specializations", t => t.Specialization_Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Racial_Id)
                .Index(t => t.RacialPreReq_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Category_Id1)
                .Index(t => t.Category_Id2)
                .Index(t => t.Character_Id)
                .Index(t => t.Specialization_Id);
            
            CreateTable(
                "dbo.Masteries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        SkillAffected_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillAffected_Id)
                .Index(t => t.SkillAffected_Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Language = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RelationToUser = c.String(),
                        PhoneHome = c.String(),
                        PhoneMobile = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        Leader_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Leader_Id)
                .ForeignKey("dbo.InstitutionTypes", t => t.Type_Id)
                .Index(t => t.Leader_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Name = c.String(),
                        Religion = c.String(),
                        AvaliableCategories = c.String(),
                        Background = c.String(),
                        Influence = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        Title = c.String(),
                        Destiny = c.Int(nullable: false),
                        IsPS = c.Boolean(nullable: false),
                        GoldGenerated = c.Int(nullable: false),
                        HitPoints = c.Int(nullable: false),
                        MinorSpells = c.Int(nullable: false),
                        MajorSpells = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        Insitution_Id = c.Int(),
                        Race_Id = c.Int(),
                        Specialization_Id = c.Int(),
                        Institution_Id = c.Int(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institutions", t => t.Insitution_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .ForeignKey("dbo.Specializations", t => t.Specialization_Id)
                .ForeignKey("dbo.Institutions", t => t.Institution_Id)
                .ForeignKey("dbo.Users", t => t.Player_Id)
                .Index(t => t.Insitution_Id)
                .Index(t => t.Race_Id)
                .Index(t => t.Specialization_Id)
                .Index(t => t.Institution_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsPermanent = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InstitutionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Archived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Birthday", c => c.DateTime());
            AddColumn("dbo.Users", "IsResident", c => c.Boolean());
            AddColumn("dbo.Users", "PostalCode", c => c.String());
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "EmergencyContact_Id", c => c.Int());
            CreateIndex("dbo.Users", "EmergencyContact_Id");
            AddForeignKey("dbo.Users", "EmergencyContact_Id", "dbo.Contacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "EmergencyContact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Characters", "Player_Id", "dbo.Users");
            DropForeignKey("dbo.Institutions", "Type_Id", "dbo.InstitutionTypes");
            DropForeignKey("dbo.Characters", "Institution_Id", "dbo.Institutions");
            DropForeignKey("dbo.Institutions", "Leader_Id", "dbo.Characters");
            DropForeignKey("dbo.Characters", "Specialization_Id", "dbo.Specializations");
            DropForeignKey("dbo.Skills", "Specialization_Id", "dbo.Specializations");
            DropForeignKey("dbo.Skills", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Characters", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Items", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Characters", "Insitution_Id", "dbo.Institutions");
            DropForeignKey("dbo.Attacks", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Skills", "Category_Id2", "dbo.Categories");
            DropForeignKey("dbo.Skills", "Category_Id1", "dbo.Categories");
            DropForeignKey("dbo.Skills", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Skills", "RacialPreReq_Id", "dbo.Categories");
            DropForeignKey("dbo.Skills", "Racial_Id", "dbo.Races");
            DropForeignKey("dbo.Skills", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.Masteries", "SkillAffected_Id", "dbo.Skills");
            DropForeignKey("dbo.Categories", "Skill_Id", "dbo.Skills");
            DropIndex("dbo.Items", new[] { "Character_Id" });
            DropIndex("dbo.Characters", new[] { "Player_Id" });
            DropIndex("dbo.Characters", new[] { "Institution_Id" });
            DropIndex("dbo.Characters", new[] { "Specialization_Id" });
            DropIndex("dbo.Characters", new[] { "Race_Id" });
            DropIndex("dbo.Characters", new[] { "Insitution_Id" });
            DropIndex("dbo.Institutions", new[] { "Type_Id" });
            DropIndex("dbo.Institutions", new[] { "Leader_Id" });
            DropIndex("dbo.Masteries", new[] { "SkillAffected_Id" });
            DropIndex("dbo.Skills", new[] { "Specialization_Id" });
            DropIndex("dbo.Skills", new[] { "Character_Id" });
            DropIndex("dbo.Skills", new[] { "Category_Id2" });
            DropIndex("dbo.Skills", new[] { "Category_Id1" });
            DropIndex("dbo.Skills", new[] { "Category_Id" });
            DropIndex("dbo.Skills", new[] { "RacialPreReq_Id" });
            DropIndex("dbo.Skills", new[] { "Racial_Id" });
            DropIndex("dbo.Skills", new[] { "Skill_Id" });
            DropIndex("dbo.Categories", new[] { "Skill_Id" });
            DropIndex("dbo.Attacks", new[] { "Character_Id" });
            DropIndex("dbo.Users", new[] { "EmergencyContact_Id" });
            DropColumn("dbo.Users", "EmergencyContact_Id");
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "PostalCode");
            DropColumn("dbo.Users", "IsResident");
            DropColumn("dbo.Users", "Birthday");
            DropColumn("dbo.Users", "Archived");
            DropTable("dbo.InstitutionTypes");
            DropTable("dbo.Specializations");
            DropTable("dbo.Items");
            DropTable("dbo.Characters");
            DropTable("dbo.Institutions");
            DropTable("dbo.Contacts");
            DropTable("dbo.Races");
            DropTable("dbo.Masteries");
            DropTable("dbo.Skills");
            DropTable("dbo.Categories");
            DropTable("dbo.Attacks");
            RenameTable(name: "dbo.Users", newName: "Animateurs");
        }
    }
}

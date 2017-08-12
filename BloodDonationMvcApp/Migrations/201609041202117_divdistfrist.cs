namespace BloodDonationMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class divdistfrist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodName = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRegs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 500, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 10, unicode: false),
                        DivisionId = c.Int(nullable: false),
                        DistrictsId = c.Int(nullable: false),
                        BloodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BloodGroups", t => t.BloodId)
                .ForeignKey("dbo.Districts", t => t.DistrictsId)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .Index(t => t.BloodId)
                .Index(t => t.DistrictsId)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DivisionId = c.Int(nullable: false),
                        DistrictsName = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DivisionName = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRegs", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.UserRegs", "DistrictsId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.UserRegs", "BloodId", "dbo.BloodGroups");
            DropIndex("dbo.UserRegs", new[] { "DivisionId" });
            DropIndex("dbo.UserRegs", new[] { "DistrictsId" });
            DropIndex("dbo.Districts", new[] { "DivisionId" });
            DropIndex("dbo.UserRegs", new[] { "BloodId" });
            DropTable("dbo.Divisions");
            DropTable("dbo.Districts");
            DropTable("dbo.UserRegs");
            DropTable("dbo.BloodGroups");
        }
    }
}

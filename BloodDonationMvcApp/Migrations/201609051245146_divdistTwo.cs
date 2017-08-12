namespace BloodDonationMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class divdistTwo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Districts", "DistrictsName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Divisions", "DivisionName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Divisions", "DivisionName", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Districts", "DistrictsName", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}

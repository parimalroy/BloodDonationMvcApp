namespace BloodDonationMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class divdisThree : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BloodGroups", "BloodName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BloodGroups", "BloodName", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}

namespace MVCTrain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivinLicense", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivinLicense");
        }
    }
}

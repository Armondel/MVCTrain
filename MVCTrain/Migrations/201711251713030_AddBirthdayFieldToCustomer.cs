namespace MVCTrain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayFieldToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthdayDate", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthdayDate");
        }
    }
}

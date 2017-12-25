using System.Data.Entity.Migrations.Model;

namespace MVCTrain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherMovieFix : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Movies DROP CONSTRAINT DF__Movies__ReleaseD__3C69FB99");
            Sql("ALTER TABLE dbo.Movies DROP CONSTRAINT DF__Movies__DateAdde__3D5E1FD2");
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}

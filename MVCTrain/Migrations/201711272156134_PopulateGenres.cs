namespace MVCTrain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (3, 'Horror')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (4, 'Action')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (5, 'Fantasy')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id = 1");
            Sql("DELETE FROM Genres WHERE Id = 2");
            Sql("DELETE FROM Genres WHERE Id = 3");
            Sql("DELETE FROM Genres WHERE Id = 4");
            Sql("DELETE FROM Genres WHERE Id = 5");
        }
    }
}

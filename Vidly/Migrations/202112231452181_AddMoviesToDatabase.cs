namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesToDatabase : DbMigration
    {
        public override void Up()
        {
            Sql(
                "insert into Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES('Dark', 3,12/12/2010,05/05/2011,50)");
            Sql(
                "insert into Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES('Hangover', 2,12/12/2010,05/05/2011,40)");
            Sql(
                "insert into Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES('Die Hard', 1,12/12/2010,05/05/2011,30)");
            Sql(
                "insert into Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES('The Terminator', 1,12/12/2010,05/05/2011,20)");
            Sql(
                "insert into Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES('Toy Story', 4,12/12/2010,05/05/2011,10)");
            Sql(
                "insert into Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES('Titanic', 3,12/12/2010,05/05/2011,5)");
            Sql(
                "insert into Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES('Friends', 1,12/12/2010,05/05/2011,3)");

        }

        public override void Down()
        {
        }
    }
}

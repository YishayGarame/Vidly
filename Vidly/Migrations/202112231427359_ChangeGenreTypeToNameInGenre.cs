namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenreTypeToNameInGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Genres", "GenreType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "GenreType", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Genres", "Name");
        }
    }
}

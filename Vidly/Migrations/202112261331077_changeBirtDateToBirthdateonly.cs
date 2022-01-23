namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBirtDateToBirthdateonly : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthdateafter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Birthdateafter", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}

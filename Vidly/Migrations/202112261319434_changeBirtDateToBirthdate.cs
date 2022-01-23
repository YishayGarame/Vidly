namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBirtDateToBirthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            DropColumn("dbo.Customers", "BirtDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BirtDate", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}

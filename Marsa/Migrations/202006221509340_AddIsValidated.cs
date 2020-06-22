namespace Marsa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsValidated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Annonces", "IsValidated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Annonces", "IsValidated");
        }
    }
}

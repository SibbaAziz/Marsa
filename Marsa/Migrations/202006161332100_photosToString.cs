namespace Marsa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photosToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Annonces", "Photos", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Annonces", "Photos");
        }
    }
}

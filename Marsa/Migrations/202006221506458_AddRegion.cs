﻿namespace Marsa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Annonces", "Region", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Annonces", "Region");
        }
    }
}

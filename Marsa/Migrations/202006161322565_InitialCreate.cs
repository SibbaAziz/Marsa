namespace Marsa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annonces",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Category = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        City = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Pseudo = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Annonces");
        }
    }
}

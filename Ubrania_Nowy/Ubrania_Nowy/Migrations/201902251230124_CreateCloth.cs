namespace Ubrania_Nowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCloth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clothes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.String(),
                        Size = c.String(),
                        Colour = c.String(),
                        Type = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Price_RL = c.Int(nullable: false),
                        Agreement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agreements", t => t.Agreement_Id)
                .Index(t => t.Agreement_Id);
            
            AddColumn("dbo.Agreements", "Begin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Agreements", "End", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clothes", "Agreement_Id", "dbo.Agreements");
            DropIndex("dbo.Clothes", new[] { "Agreement_Id" });
            DropColumn("dbo.Agreements", "End");
            DropColumn("dbo.Agreements", "Begin");
            DropTable("dbo.Clothes");
        }
    }
}

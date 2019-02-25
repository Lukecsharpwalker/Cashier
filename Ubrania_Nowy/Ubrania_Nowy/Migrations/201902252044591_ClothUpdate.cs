namespace Ubrania_Nowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClothUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clothes", "Agreement_Id", "dbo.Agreements");
            DropIndex("dbo.Clothes", new[] { "Agreement_Id" });
            AlterColumn("dbo.Clothes", "Agreement_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Clothes", "Agreement_Id");
            AddForeignKey("dbo.Clothes", "Agreement_Id", "dbo.Agreements", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clothes", "Agreement_Id", "dbo.Agreements");
            DropIndex("dbo.Clothes", new[] { "Agreement_Id" });
            AlterColumn("dbo.Clothes", "Agreement_Id", c => c.Int());
            CreateIndex("dbo.Clothes", "Agreement_Id");
            AddForeignKey("dbo.Clothes", "Agreement_Id", "dbo.Agreements", "Id");
        }
    }
}

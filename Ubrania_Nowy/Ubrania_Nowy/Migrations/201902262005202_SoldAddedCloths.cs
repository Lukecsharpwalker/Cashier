namespace Ubrania_Nowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoldAddedCloths : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clothes", "Sold", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clothes", "Sold");
        }
    }
}

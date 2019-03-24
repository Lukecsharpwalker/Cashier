namespace Ubrania_Nowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeselIntToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agreements", "Pesel", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agreements", "Pesel", c => c.Int(nullable: false));
        }
    }
}

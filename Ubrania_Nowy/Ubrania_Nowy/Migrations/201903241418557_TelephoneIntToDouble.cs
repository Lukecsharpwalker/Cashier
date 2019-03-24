namespace Ubrania_Nowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TelephoneIntToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agreements", "Tel", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agreements", "Tel", c => c.Int(nullable: false));
        }
    }
}

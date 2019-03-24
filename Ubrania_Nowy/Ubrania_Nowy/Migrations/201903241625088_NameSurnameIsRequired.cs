namespace Ubrania_Nowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameSurnameIsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agreements", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Agreements", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agreements", "Surname", c => c.String());
            AlterColumn("dbo.Agreements", "Name", c => c.String());
        }
    }
}

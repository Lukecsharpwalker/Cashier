namespace Ubrania_Nowy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAgrement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agreements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Tel = c.Int(nullable: false),
                        Pesel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agreements");
        }
    }
}

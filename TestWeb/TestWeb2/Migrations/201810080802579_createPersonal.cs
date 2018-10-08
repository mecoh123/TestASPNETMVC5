namespace TestWeb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createPersonal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personals");
        }
    }
}

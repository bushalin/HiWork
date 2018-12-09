namespace HiWork.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 20),
                        Password = c.String(),
                        FirstName = c.String(maxLength: 75),
                        LastName = c.String(maxLength: 75),
                        Address = c.String(maxLength: 500),
                        BirthDate = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}

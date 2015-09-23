namespace NoTrace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_login : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        LoginProvider = c.String(nullable: false),
                        ProviderKey = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLogin");
        }
    }
}

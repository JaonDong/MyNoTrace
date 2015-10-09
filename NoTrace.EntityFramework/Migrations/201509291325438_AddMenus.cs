namespace NoTrace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        Url = c.String(),
                        PictureUrl = c.String(),
                        IsTop = c.Boolean(nullable: false),
                        ParentMenu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.ParentMenu_Id)
                .Index(t => t.ParentMenu_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "ParentMenu_Id", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "ParentMenu_Id" });
            DropTable("dbo.Menus");
        }
    }
}

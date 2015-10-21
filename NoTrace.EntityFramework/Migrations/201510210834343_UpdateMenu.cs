namespace NoTrace.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenu : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        Url = c.String(),
                        PictureUrl = c.String(),
                        IsTop = c.Boolean(nullable: false),
                        TenantId = c.Int(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        ParentMenu_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Menu_MustHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Menus", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Menus", "IsShow", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "IsShow");
            DropColumn("dbo.Menus", "TenantId");
            AlterTableAnnotations(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        Url = c.String(),
                        PictureUrl = c.String(),
                        IsTop = c.Boolean(nullable: false),
                        TenantId = c.Int(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        ParentMenu_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Menu_MustHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}

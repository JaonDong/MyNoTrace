namespace NoTrace.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class myabptest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TenantId = c.Int(),
                        IsStatic = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorUserId)
                .ForeignKey("dbo.Users", t => t.DeleterUserId)
                .ForeignKey("dbo.Users", t => t.LastModifierUserId)
                .ForeignKey("dbo.Tenants", t => t.TenantId)
                .Index(t => t.TenantId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        EmailConfiremationCode = c.String(),
                        ResetPasswordCode = c.String(),
                        LastLoginTime = c.DateTime(),
                        TenatId = c.Int(),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorUserId)
                .ForeignKey("dbo.Users", t => t.DeleterUserId)
                .ForeignKey("dbo.Users", t => t.LastModifierUserId)
                .ForeignKey("dbo.Tenants", t => t.TenatId)
                .Index(t => t.TenatId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tenant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorUserId)
                .ForeignKey("dbo.Users", t => t.DeleterUserId)
                .ForeignKey("dbo.Users", t => t.LastModifierUserId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.Roles", "LastModifierUserId", "dbo.Users");
            DropForeignKey("dbo.Roles", "DeleterUserId", "dbo.Users");
            DropForeignKey("dbo.Roles", "CreatorUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "TenatId", "dbo.Tenants");
            DropForeignKey("dbo.Tenants", "LastModifierUserId", "dbo.Users");
            DropForeignKey("dbo.Tenants", "DeleterUserId", "dbo.Users");
            DropForeignKey("dbo.Tenants", "CreatorUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "LastModifierUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "DeleterUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CreatorUserId", "dbo.Users");
            DropIndex("dbo.Tenants", new[] { "CreatorUserId" });
            DropIndex("dbo.Tenants", new[] { "LastModifierUserId" });
            DropIndex("dbo.Tenants", new[] { "DeleterUserId" });
            DropIndex("dbo.Users", new[] { "CreatorUserId" });
            DropIndex("dbo.Users", new[] { "LastModifierUserId" });
            DropIndex("dbo.Users", new[] { "DeleterUserId" });
            DropIndex("dbo.Users", new[] { "TenatId" });
            DropIndex("dbo.Roles", new[] { "CreatorUserId" });
            DropIndex("dbo.Roles", new[] { "LastModifierUserId" });
            DropIndex("dbo.Roles", new[] { "DeleterUserId" });
            DropIndex("dbo.Roles", new[] { "TenantId" });
            DropTable("dbo.Tenants",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tenant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Users",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Roles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}

namespace OTS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        groupName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        group_ID = c.Int(),
                        role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.group_ID)
                .ForeignKey("dbo.Role", t => t.role_ID)
                .Index(t => t.group_ID)
                .Index(t => t.role_ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        roleName = c.String(),
                        roleDesc = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.User", "group_ID", c => c.Int());
            CreateIndex("dbo.User", "group_ID");
            AddForeignKey("dbo.User", "group_ID", "dbo.Group", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupRoles", "role_ID", "dbo.Role");
            DropForeignKey("dbo.GroupRoles", "group_ID", "dbo.Group");
            DropForeignKey("dbo.User", "group_ID", "dbo.Group");
            DropIndex("dbo.GroupRoles", new[] { "role_ID" });
            DropIndex("dbo.GroupRoles", new[] { "group_ID" });
            DropIndex("dbo.User", new[] { "group_ID" });
            DropColumn("dbo.User", "group_ID");
            DropTable("dbo.Role");
            DropTable("dbo.GroupRoles");
            DropTable("dbo.Group");
        }
    }
}

namespace likeWorkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        UserLoginID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        Surname = c.String(),
                        EmployeeIdNumber = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.UserLogins", t => t.UserLoginID, cascadeDelete: true)
                .Index(t => t.UserLoginID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        UserLoginID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserLoginID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        LeaveID = c.Int(nullable: false, identity: true),
                        AppliedOn = c.DateTime(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        ReasonForLeave = c.String(nullable: false),
                        LeaveTypeID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        AssessedBy = c.Int(nullable: false),
                        AssessedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.LeaveTypes", t => t.LeaveTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.LeaveTypeID)
                .Index(t => t.EmployeeID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.LeaveTypes",
                c => new
                    {
                        LeaveTypeID = c.Int(nullable: false, identity: true),
                        LeaveTypeName = c.String(),
                        AddedByID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveTypeID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.StatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaves", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Leaves", "LeaveTypeID", "dbo.LeaveTypes");
            DropForeignKey("dbo.Leaves", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "UserLoginID", "dbo.UserLogins");
            DropForeignKey("dbo.UserLogins", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Leaves", new[] { "StatusID" });
            DropIndex("dbo.Leaves", new[] { "EmployeeID" });
            DropIndex("dbo.Leaves", new[] { "LeaveTypeID" });
            DropIndex("dbo.UserLogins", new[] { "RoleID" });
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            DropIndex("dbo.Employees", new[] { "UserLoginID" });
            DropTable("dbo.Status");
            DropTable("dbo.LeaveTypes");
            DropTable("dbo.Leaves");
            DropTable("dbo.Roles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}

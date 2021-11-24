namespace AbcJobSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicantName = c.String(nullable: false),
                        ApplicantEmail = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreatedUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobApplication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicantId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        DateOfAplication = c.DateTime(nullable: false),
                        Employer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicant", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Employer", t => t.Employer_Id)
                .ForeignKey("dbo.Job", t => t.JobId, cascadeDelete: true)
                .Index(t => t.ApplicantId)
                .Index(t => t.JobId)
                .Index(t => t.Employer_Id);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(nullable: false),
                        JobDescription = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        TypeOfJob = c.Int(nullable: false),
                        EmployerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employer", t => t.EmployerId, cascadeDelete: true)
                .Index(t => t.EmployerId);
            
            CreateTable(
                "dbo.Employer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployerEmail = c.String(nullable: false),
                        EmployerName = c.String(nullable: false),
                        EmployerAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicant", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Skill", "ApplicantId", "dbo.Applicant");
            DropForeignKey("dbo.JobApplication", "JobId", "dbo.Job");
            DropForeignKey("dbo.Job", "EmployerId", "dbo.Employer");
            DropForeignKey("dbo.JobApplication", "Employer_Id", "dbo.Employer");
            DropForeignKey("dbo.JobApplication", "ApplicantId", "dbo.Applicant");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Skill", new[] { "ApplicantId" });
            DropIndex("dbo.Job", new[] { "EmployerId" });
            DropIndex("dbo.JobApplication", new[] { "Employer_Id" });
            DropIndex("dbo.JobApplication", new[] { "JobId" });
            DropIndex("dbo.JobApplication", new[] { "ApplicantId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Skill");
            DropTable("dbo.Employer");
            DropTable("dbo.Job");
            DropTable("dbo.JobApplication");
            DropTable("dbo.Applicant");
        }
    }
}

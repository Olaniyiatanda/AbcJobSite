namespace AbcJobSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicant", "Skill", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicant", "Skill");
        }
    }
}

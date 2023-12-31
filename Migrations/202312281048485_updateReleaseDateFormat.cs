﻿namespace VideoRentalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateReleaseDateFormat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}

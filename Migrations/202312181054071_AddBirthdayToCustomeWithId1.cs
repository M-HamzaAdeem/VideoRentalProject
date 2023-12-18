namespace VideoRentalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayToCustomeWithId1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '1994-10-27' WHERE id =1");
        
    }
        
        public override void Down()
        {
        }
    }
}

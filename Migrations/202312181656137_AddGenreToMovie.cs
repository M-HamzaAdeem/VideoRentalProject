namespace VideoRentalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoviesGenre",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.GenreId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoviesGenre", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.MoviesGenre", "MovieId", "dbo.Movies");
            DropIndex("dbo.MoviesGenre", new[] { "GenreId" });
            DropIndex("dbo.MoviesGenre", new[] { "MovieId" });
            DropTable("dbo.MoviesGenre");
            DropTable("dbo.Genres");
        }
    }
}

namespace MovieAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        CinemaID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Website = c.String(),
                        PhoneNumber = c.String(),
                        TicketPrice = c.String(),
                        RunTime = c.Double(nullable: false),
                        FilmID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CinemaID)
                .ForeignKey("dbo.MovieListings", t => t.FilmID)
                .Index(t => t.FilmID);
            
            AlterColumn("dbo.MovieListings", "Title", c => c.String());
            AlterColumn("dbo.MovieListings", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cinemas", "FilmID", "dbo.MovieListings");
            DropIndex("dbo.Cinemas", new[] { "FilmID" });
            AlterColumn("dbo.MovieListings", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.MovieListings", "Title", c => c.String(nullable: false));
            DropTable("dbo.Cinemas");
        }
    }
}

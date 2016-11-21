namespace MovieAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieListings",
                c => new
                    {
                        FilmID = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false),
                        Certification = c.Int(nullable: false),
                        Genre = c.String(nullable: false),
                        Description = c.String(),
                        RunTime = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FilmID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieListings");
        }
    }
}

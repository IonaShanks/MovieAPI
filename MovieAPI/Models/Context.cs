using System.Data.Entity;

namespace MovieAPI.Models
{


    public class MovieContext : DbContext
    {
        public MovieContext() : base("DefaultConnection")
        {

        }
        public DbSet<MovieListing> Listings { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
    }


}
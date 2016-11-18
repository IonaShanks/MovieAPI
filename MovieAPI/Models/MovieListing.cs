using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieAPI.Models
{
    public enum Certification
    {
        [Display(Name = "G")]
        G,
        [Display(Name = "PG")]
        PG,
        [Display(Name = "12")]
        Twelve,
        [Display(Name = "12A")]
        TwelveA,
        [Display(Name = "15")]
        Fifteen,
        [Display(Name = "18")]
        Eighteen
    };
    public class MovieListing
    {
        //Film ID title certification genre description running time
        [Key, Required]
        public String FilmID { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public Certification Certification { get; set; }
        [Required]
        public String Genre { get; set; }
        public String Description { get; set; }
        [Required]
        // Minutes
        public double RunTime { get; set; }

    }

    public class MovieContext : DbContext
    {
        public MovieContext() : base("MovieListing")
        {

        }
        public DbSet<MovieListing> Listings { get; set; }
        //public DbSet<Cinema> Cinemas { get; set; }
    }
}
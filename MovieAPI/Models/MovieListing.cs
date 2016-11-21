using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;



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
        [Key]
        public String FilmID { get; set; }
        public String Title { get; set; }
        public Certification Certification { get; set; }
        public String Genre { get; set; }
        public String Description { get; set; }
        public double RunTime { get; set; }

        public virtual List<Cinema> Cinemas { get; set; }

    }


}
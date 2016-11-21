using System;
using System.ComponentModel.DataAnnotations;


namespace MovieAPI.Models
{
    public class Cinema
    {
        [Key]
        public String CinemaID { get; set; }
        public String Name { get; set; }
        [Url]
        public String Website { get; set; }
        public String PhoneNumber { get; set; }
        public String TicketPrice { get; set; }
        


        public String FilmID { get; set; }
        public virtual MovieListing Listing { get; set; }
    }




}
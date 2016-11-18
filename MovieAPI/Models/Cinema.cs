using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
        public double TicketPrice { get; set; }
        public double RunTime { get; set; }
    }
    
}
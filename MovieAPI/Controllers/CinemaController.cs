using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieModel;

namespace MovieAPI.Controllers
{
    
    public class CinemaController : ApiController
    {
        private MovieContext db = new MovieContext();

        public IHttpActionResult GetAllCinemas()
        {
            if (db.Cinemas.Count() == 0)
            {
                return NotFound();
            }

            else
            {
                return Ok(db.Cinemas.OrderBy(l => l.Name).ToList());       // 200 OK, listings serialized in response body 
            }
        }


        public IHttpActionResult PostAddCinema(Cinema cinema)
        {
            if (ModelState.IsValid)                                             // model class validation ok?
            {
                // check for duplicate
                // LINQ query - get record
                var record = db.Cinemas.SingleOrDefault(l => l.CinemaID.ToUpper() == cinema.CinemaID.ToUpper());
                if (record == null)
                {
                    db.Cinemas.Add(cinema);
                    db.SaveChanges();                                           // commit

                    // create http response with Created status code and listing serialised as content and Location header set to URI for new resource
                    string uri = Url.Link("DefaultApi", new { CinemaID = cinema.CinemaID });         // name of default route in WebApiConfig.cs
                    return Created(uri, cinema);
                }
                else
                {
                    return BadRequest("resource already exists");      // 400, already exists
                }
            }
            else
            {
                return BadRequest(ModelState);        // 400
            }
        }
    }
}

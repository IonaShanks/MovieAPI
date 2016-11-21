using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieModel;

namespace MovieAPI.Controllers
{
    public class MovieListingController : ApiController
    {

        private MovieContext db = new MovieContext();

        public IHttpActionResult GetAllListings()
        {
            if (db.Listings.Count() == 0)
            {
                return NotFound();
            }

            else
            {
                return Ok(db.Listings.OrderBy(l => l.Title).ToList());       // 200 OK, listings serialized in response body 
            }
        }

        // GET api/movieListing/HP1 or api/movieListing?FilmID=HP1
        public IHttpActionResult GetMovieCertification(String ID)
        {
            // LINQ query, find matching FilmID (case-insensitive) or default value (null) if none matching
            MovieListing listing = db.Listings.SingleOrDefault(l => l.FilmID.ToUpper() == ID.ToUpper());
            if (listing == null)
            {
                return NotFound();          // 404
            }
            return Ok(listing.Certification);
        }

        // POST api/movieListing, request body contains movie listing serialized as XML or JSON
        public IHttpActionResult PostAddListing(MovieListing listing)
        {
            if (ModelState.IsValid)                                             // model class validation ok?
            {
                // check for duplicate
                // LINQ query - get record
                var record = db.Listings.SingleOrDefault(l => l.FilmID.ToUpper() == listing.FilmID.ToUpper());
                if (record == null)
                {
                    db.Listings.Add(listing);
                    db.SaveChanges();                                           // commit

                    // create http response with Created status code and listing serialised as content and Location header set to URI for new resource
                    string uri = Url.Link("DefaultApi", new { FilmID = listing.FilmID });         // name of default route in WebApiConfig.cs
                    return Created(uri, listing);
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

            //Example Listing 
            //{
            //  "FilmID": "HP1",
            //  "Title": "Harry Potter and the Philosopher's Stone",
            //  "Certification": 1,
            //  "Genre": "Fantasy",
            //  "Description": "Adaptation of the first of J.K. Rowling's popular children's novels about Harry Potter, a boy who learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own.",
            //  "RunTime": 159
            //}
        }

        // update a listing i.e. update the runtime for specified Movie
        public IHttpActionResult PutUpdateListing(String ID, MovieListing listing)                  // listing will be in request body
        {
            if (ModelState.IsValid)
            {
                if (ID == listing.FilmID)
                {
                    var record = db.Listings.SingleOrDefault(l => l.FilmID.ToUpper() == ID.ToUpper());
                    if (record == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        record.RunTime = listing.RunTime;               // update price
                        db.SaveChanges();                           // commit
                        return Ok(record);                          // or 204 with no content
                    }
                }
                else
                {
                    return BadRequest("invalid Film ID");        // 400
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        // delete the listing for specified FilmID
        public IHttpActionResult DeleteListing(String ID)
        {
            var record = db.Listings.SingleOrDefault(l => l.FilmID.ToUpper() == ID.ToUpper());
            if (record != null)
            {
                db.Listings.Remove(record);
                db.SaveChanges();                   // commit
                return Ok(record);                  // 200 ok with entity, or 204 with no content
            }
            else
            {
                return NotFound();
            }
        }
    }
}

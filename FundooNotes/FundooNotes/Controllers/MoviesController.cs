using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingMicroservice.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private object _context;
        //private readonly _Movies;

        //public MoviesController(IMovies movies)
        //{
        //    _movies = movies;
        //}

        [HttpGet("Movies")]
        public async Task<ActionResult<IEnumerable<MoviesController>>> GetMovies()
        {
            throw new System.Exception("An error occurred");
            //return await _context.Movies.ToListAsync();
        }
    }
}
    

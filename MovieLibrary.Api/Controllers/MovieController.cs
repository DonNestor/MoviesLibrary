using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Services;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;

namespace MovieLibrary.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v1/MovieManagement")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movies)
        {
            _movieService = movies;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDTO>> GetAll([FromQuery] MovieQuery mQuery)
        {
            var moviesDTO = _movieService.GetAll(mQuery);
            return Ok(moviesDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<MovieDTO> GetMovieById([FromRoute] int id)
        {
            var movieDTO = _movieService.GetById(id);
            if(movieDTO is null)
            {
                return NotFound(); 
            }

            return Ok(movieDTO);
        }

       [HttpPost]
       public ActionResult AddMovie([FromBody] CreateMovieDTO cMovieDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMovie = _movieService.AddMovie(cMovieDTO);
            return Created($"/api/vi/MovieManagement/{newMovie}", null);
        }
        
        [HttpPut("{id}")]
        public ActionResult ChangeMovies([FromRoute] int id, [FromBody] UpdateMovieDTO updateMovieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var changedRestaurant = _movieService.ChangeMovieById(id, updateMovieDTO);

            if (changedRestaurant is false)
            {
                return NotFound();
            }

            return Ok();
        }



        [HttpDelete("{id}")]
        public ActionResult DeleteMovie([FromRoute] int id)
        {
            var isDelete = _movieService.DeleteMovie(id);
            if(isDelete)
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_API.Data;
using Movie_API.Models;

namespace Movie_API.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MovieesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetMovie()
        {
            var movie = _context.Moviess.ToList();
            return Ok(movie);
        }
        [HttpPost]
        public IActionResult CreateMovie([FromBody] Movies movies)
        {
            if (movies == null) return BadRequest();
            _context.Moviess.Add(movies);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMovie([FromBody] Movies movie)
        {
            if (movie == null) return BadRequest();
            _context.Moviess.Update(movie);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Moviess.Find(id);
            if (movie.Id == null) return BadRequest();
            _context.Moviess.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("SreachByMovie")]
        public IActionResult SreachMovie(string name)
        {
            if (name == null) return NotFound();
            var actor = _context.Moviess.Where(m => m.Title == name).ToList();
            if (actor.Count == 0) return BadRequest();
            return Ok(actor);
        }

        [HttpGet("SreachByActor")]
        public IActionResult SreachActor(string name)
        {
            if (name == null) return NotFound();
            var actor = _context.Moviess.Where(m => m.Actor == name).ToList();
            if (actor.Count == 0) return BadRequest();
            return Ok(actor);
        }
    }
}

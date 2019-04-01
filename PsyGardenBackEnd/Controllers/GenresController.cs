using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Genre>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            IEnumerable<Genre> genres = _genreRepository.GetAll().OrderBy(g => g.Name).ToList();
            if (genres == null) {
                return NotFound();
            }
            else {
                return Ok(genres);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Genre> Get(int id)
        {
            Genre genre = _genreRepository.GetById(id);
            if (genre == null) {
                return NotFound();
            }
            else {
                return Ok(genre);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Genre> Post(Genre genre)
        {
            try {
                _genreRepository.Add(genre);
                _genreRepository.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = genre.GenreId }, genre);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(int id, Genre genre)
        {
            if (id != genre.GenreId) {
                return BadRequest();
            }
            else {
                _genreRepository.Update(genre);
                _genreRepository.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            Genre genre = _genreRepository.GetById(id);
            if (genre == null) {
                return NoContent();
            }
            else {
                _genreRepository.Delete(genre);
                _genreRepository.SaveChanges();
                return Ok();
            }
        }
    }
}

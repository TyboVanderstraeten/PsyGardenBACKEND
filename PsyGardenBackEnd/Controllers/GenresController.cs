using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsyGardenBackEnd.DTO;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GenresController : ControllerBase
    {
        private IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns>All genres</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Genre>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Genre>> GetGenres()
        {
            IEnumerable<Genre> genres = _genreRepository.GetAll().OrderBy(g => g.Name).ToList();
            if (genres == null) {
                return NotFound();
            }
            else {
                return Ok(genres);
            }
        }
        /// <summary>
        /// Get the genre with given id
        /// </summary>
        /// <param name="id">The id of the genre</param>
        /// <returns>The genre</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Genre> GetGenre(int id)
        {
            Genre genre = _genreRepository.GetById(id);
            if (genre == null) {
                return NotFound();
            }
            else {
                return Ok(genre);
            }
        }

        /// <summary>
        /// Create the genre
        /// </summary>
        /// <param name="genre">The genre to be created</param>
        /// <returns>The genre</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Genre> PostGenre(GenreDTO genre)
        {
            try {
                Genre genreToCreate = new Genre() { Name = genre.Name };
                _genreRepository.Add(genreToCreate);
                _genreRepository.SaveChanges();
                return CreatedAtAction(nameof(GetGenre), new { id = genreToCreate.GenreId }, genreToCreate);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edit the genre with given id
        /// </summary>
        /// <param name="id">The id of the genre</param>
        /// <param name="genre">The genre to be edited</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PutGenre(int id, GenreDTO genre)
        {
            Genre genreToEdit = _genreRepository.GetById(id);
            if (genreToEdit == null) {
                return NotFound();
            }
            else {
                genreToEdit.Name = genre.Name;
                _genreRepository.Update(genreToEdit);
                _genreRepository.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Delete the genre with given id
        /// </summary>
        /// <param name="id">The id of the genre</param>
        /// <returns>The genre</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Genre> DeleteGenre(int id)
        {
            Genre genre = _genreRepository.GetById(id);
            if (genre == null) {
                return NotFound();
            }
            else {
                _genreRepository.Delete(genre);
                _genreRepository.SaveChanges();
                return Ok(genre);
            }
        }
    }
}

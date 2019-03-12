using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        #region Properties
        private PsyGardenDBContext _dbContext;
        private DbSet<Genre> _genres;
        #endregion

        #region Constructors
        public GenreRepository(PsyGardenDBContext dbContext)
        {
            _dbContext = dbContext;
            _genres = dbContext.Genres;
        }
        #endregion

        #region Methods
        public IEnumerable<Genre> GetAll()
        {
            return _genres.ToList();
        }

        public Genre GetById(int genreId)
        {
            return _genres.SingleOrDefault(g => g.GenreId == genreId);
        }

        public void Add(Genre genre)
        {
            _genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            _genres.Update(genre);
        }

        public void Delete(Genre genre)
        {
            _genres.Remove(genre);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        #endregion

    }
}

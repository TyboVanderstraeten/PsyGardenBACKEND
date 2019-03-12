using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();
        Genre GetById(int genreId);
        void Add(Genre genre);
        void Update(Genre genre);
        void Delete(Genre genre);
        void SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public Genre()
        {
            
        }

        public Genre(string name)
        {
            Name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Genre
    {
        #region Properties
        public int GenreId { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructors
        public Genre()
        {

        }

        public Genre(string name)
        {
            Name = name;
        } 
        #endregion
    }
}

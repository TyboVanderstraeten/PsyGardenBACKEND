using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Genre
    {
        #region Backingfields
        private string _name;
        #endregion

        #region Properties
        public int GenreId { get; set; }
        public string Name {
            get {
                return _name;
            }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("Name is required");
                }
                else if (value.Length > 25) {
                    throw new ArgumentException("Name contains 25 chars. max");
                }
                else {
                    _name = value;
                }
            }
        }
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

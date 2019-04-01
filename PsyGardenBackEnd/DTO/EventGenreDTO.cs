using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.DTO
{
    public class EventGenreDTO
    {
        [Required]
        public int GenreId { get; set; }
    }
}

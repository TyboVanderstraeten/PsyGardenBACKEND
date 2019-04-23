using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.DTO
{
    public class GenreDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, ErrorMessage = "Name contains 25 chars. max")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}

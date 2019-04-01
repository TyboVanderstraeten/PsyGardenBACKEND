using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.DTO
{
    public class PriceDTO
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        [Range(0, 5000)]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
    }
}

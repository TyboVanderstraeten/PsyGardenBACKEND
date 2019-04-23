using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.DTO
{
    public class PriceDTO
    {
        public int PriceId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name contains 50 chars. max")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [Range(0, 5000, ErrorMessage = "Cost is in range 0-5000")]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
    }
}

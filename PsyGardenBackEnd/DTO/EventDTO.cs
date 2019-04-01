using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.DTO
{
    public class EventDTO
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public Country Country { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Region { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Street { get; set; }
        [Required]
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string StreetNr { get; set; }
        [Required]
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string ZipCode { get; set; }

        public IList<EventGenreDTO> EventGenres { get; set; }
        public IList<PriceDTO> Prices { get; set; }
        public IList<ResourceDTO> Resources { get; set; }
    }
}

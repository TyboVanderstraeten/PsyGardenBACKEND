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
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name contains 50 chars. max")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Startdate is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Enddate is required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(100, ErrorMessage = "Country contains 100 chars. max")]
        public string Country { get; set; }

        [StringLength(100, ErrorMessage = "Region contains 100 chars. max")]
        [DataType(DataType.Text)]
        public string Region { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(100, ErrorMessage = "City contains 100 chars. max")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(100, ErrorMessage = "Street contains 100 chars. max")]
        [DataType(DataType.Text)]
        public string Street { get; set; }

        [StringLength(10, ErrorMessage = "Street number contains 10 chars. max")]
        [DataType(DataType.Text)]
        public string StreetNr { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        [StringLength(10, ErrorMessage = "Zipcode contains 10 chars. max")]
        [DataType(DataType.Text)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Headerimage-URL is required")]
        [StringLength(100, ErrorMessage = "Headerimage-URL contains 100 chars. max")]
        [DataType(DataType.Text)]
        public string HeaderImageURL { get; set; }

        public IList<EventGenreDTO> EventGenres { get; set; }
        public IList<PriceDTO> Prices { get; set; }
        public IList<LinkDTO> Links { get; set; }
    }
}

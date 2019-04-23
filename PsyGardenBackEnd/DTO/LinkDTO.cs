using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.DTO
{
    public class LinkDTO
    {
        public int LinkId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name contains 50 chars. max")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "URL is required")]
        [StringLength(100, ErrorMessage = "URL contains 100 chars. max")]
        [DataType(DataType.Text)]
        public string Url { get; set; }
    }
}

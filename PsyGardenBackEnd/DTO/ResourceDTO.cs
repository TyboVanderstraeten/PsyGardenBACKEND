using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.DTO
{
    public class ResourceDTO
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Url { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Alt { get; set; }
    }
}

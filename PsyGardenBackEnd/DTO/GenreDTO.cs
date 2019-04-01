﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.DTO
{
    public class GenreDTO
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public abstract class Resource
    {
        public int ResourceId { get; set; }

        public Resource()
        {

        }
    }
}
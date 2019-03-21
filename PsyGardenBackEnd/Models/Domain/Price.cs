﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Price
    {
        #region Properties
        public int PriceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        #endregion

        #region Constructors
        public Price()
        {

        }

        public Price(string name, string description, decimal cost)
        {
            Name = name;
            Description = description;
            Cost = cost;
        } 
        #endregion
    }
}

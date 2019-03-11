using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Price
    {
        public string Description { get; set; }
        public decimal Cost { get; set; }

        protected Price()
        {

        }

        public Price(string description,decimal cost)
        {
            Description = description;
            Cost = cost;
        }
    }
}

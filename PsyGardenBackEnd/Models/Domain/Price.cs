using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Price
    {
        public int PriceId { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public Price()
        {

        }

        public Price(string description,decimal cost)
        {
            Description = description;
            Cost = cost;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Link : Resource
    {

        public Link()
        {

        }

        public Link(string name, string url) : base(name, url)
        {
        }
    }
}

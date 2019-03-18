using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Link : Resource
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public Link()
        {

        }

        public Link(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}

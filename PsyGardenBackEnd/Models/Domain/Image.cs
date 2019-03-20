using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Image : Resource
    {
        public string Alt { get; set; }

        public Image()
        {

        }

        public Image(string name, string url, string alt) : base(name, url)
        {

            Alt = alt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Link
    {
        #region Properties
        public int LinkId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        #endregion

        #region Constructors
        public Link()
        {

        }

        public Link(string name, string url)
        {
            Name = name;
            Url = url;
        } 
        #endregion
    }
}

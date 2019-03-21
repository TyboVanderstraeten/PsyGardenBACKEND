using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Resource
    {
        #region Properties
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        #endregion

        #region Constructors
        public Resource()
        {

        }

        public Resource(string name, string url)
        {
            Name = name;
            Url = url;
        } 
        #endregion
    }
}

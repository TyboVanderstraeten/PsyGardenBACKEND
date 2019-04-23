using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Link
    {
        #region Backingfields
        private string _name;
        private string _url;
        #endregion

        #region Properties
        public int LinkId { get; set; }

        public string Name {
            get { return _name; }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("Name is required");
                }
                else if (value.Length > 50) {
                    throw new ArgumentException("Name contains 50 chars. max");
                }
                else {
                    _name = value;
                }
            }
        }

        public string Url {
            get { return _url; }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("URL is required");
                }
                else if (value.Length > 100) {
                    throw new ArgumentException("URL contains 100 chars. max");
                }
                else {
                    _url = value;
                }
            }
        }
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

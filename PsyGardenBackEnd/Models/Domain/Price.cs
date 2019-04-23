using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Price
    {
        #region Backingfields
        private string _name;
        private string _description;
        private decimal _cost;
        #endregion

        #region Properties
        public int PriceId { get; set; }

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

        public string Description {
            get { return _description; }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("Description is required");
                }
                else {
                    _description = value;
                }
            }
        }

        public decimal Cost {
            get { return _cost; }
            set {
                if (value < 0M || value > 5000M) {
                    throw new ArgumentException("Cost is in range 0-5000");
                }
                else {
                    _cost = value;
                }
            }
        }
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

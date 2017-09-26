using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile {
    /// <summary>
    /// Represents a product
    /// </summary>
    /// <remarks>This will represent a product with other stuff</remarks>
    public class Product 
    {
        /// <summary> Gets or sets the description</summary>
        /// ///<value>Never returns null</value>
        public string Name
        {
            // string get_Name ()
            get 
            {
                return _name ?? "";
            }

            // void set_Name (string value)
            set
            {
                _name = value?.Trim();
            }
        }

        /// <summary> Gets or sets the description</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the price</summary>
        public decimal Price { get; set; } = 0;

        /// <summary> Determines if discontinued</summary>
        public bool IsDiscontinued { get; set; }


        public const decimal DiscontinuedDiscountRate = 0.10M;
        /// <summary>Gets the discounted price, if applicable</summary>
        /// <returns>The price</returns>
        public decimal DiscountedPrice
        {
            get 
            {
                if (IsDiscontinued)
                    return Price * DiscontinuedDiscountRate;
                return Price;
            }
        }
        private string _name;
        private string _description;

        // notes and stuff
        /*public int ICanOnlySetIt { get; private set; }
        public int ICanOnlySetIt2 { get;}

        private readonly double _someValueICantChange = 10;
        public readonly Product None = new Product();*/

        // when to use property: should be fast.
        // gets should have no side effects
        // property should return same value over and over until the object changes

        // methods:
        // if member trying to define does not represent data, should be method
        // if you need parameters to perform action
        // if allocate memory

        //if unsure, lean towards methods
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile {
    /// <summary>
    /// Represents a product
    /// </summary>
    /// <remarks>This will represent a product with other stuff</remarks>
    public class Product : IValidatableObject
    {
        /// <summary> Gets or sets the description</summary>
        /// ///<value>Never returns null</value>
        public string Name
        {
            get { return _name ?? "";}
            set { _name = value?.Trim(); }
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

        /// <summary> Gets or sets the unique identifier</summary>
        public int Id { get; set; }

        /// <summary>Gets the discounted price, if applicable</summary>
        /// <returns>The price</returns>
        
        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {

            //var errors = new List<ValidationResult>();
            // name cannot be empty
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name cannot be empty.", new[] { nameof(Name) });
                //errors.Add(new ValidationResult("Name cannot be empty.", new[] { nameof(Name) }));

            // price >= 0
            if (Price < 0)
                yield return new ValidationResult("Prices must be >= 0.", new[] { nameof(Price) });
                //errors.Add(new ValidationResult("Prices must be >= 0.", new[] { nameof(Price) }));
                //return errors;
        }

        public override string ToString()
        {
            return Name;
        }
        
        private string _name;
        private string _description;

        // notes and stuff

        // when to use property: should be fast.
        // gets should have no side effects
        // property should return same value over and over until the object changes

        // methods:
        // if member trying to define does not represent data, should be method
        // if you need parameters to perform action
        // if allocate memory

        //if unsure, lean towards methods

        // constructors used for:
        // cross field initialization

        //list / collections are readable and writiable
        // arrays readable and replacable
        // IEnumerable is read only

        // abstract and virtual do the same thing. abstract, all derived MUST provide implementation
        // cant create instance of abstract class types
    }
}

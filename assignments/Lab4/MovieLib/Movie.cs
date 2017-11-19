//Trey Kreis
//ITSE 1430
//October 26, 2017


using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib 
{
    /// <summary>Represents a movie.</summary>
    public class Movie : IValidatableObject
    {
        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            get { return _title ?? ""; }
            set { _title = value?.Trim(); }
        }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the length of the movie.</summary>
        public int Length { get; set; } = 0;

        /// <summary>Gets or sets the unique identifier</summary>
        public int Id { get; set; }

        /// <summary>Determines if the movie is owned or not.</summary>
        public bool IsOwned { get; set; }
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult( "Name cannot be empty.", new[] { nameof(Title) } );
            }

            if (Length < 0)
            {
                yield return new ValidationResult("Length must be >= 0.", new[] { nameof(Length) });
            }
        }

        private string _title;
        private string _description;
    }
}

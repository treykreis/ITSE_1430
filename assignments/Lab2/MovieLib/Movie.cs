//Trey Kreis
//ITSE 1430
//October 7, 2017


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib 
{
    /// <summary>Represents a movie.</summary>
    public class Movie 
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

        /// <summary>Determines if the movie is owned or not.</summary>
        public bool IsOwned { get; set; }

        /// <summary>Validates the movie.</summary>
        /// <returns>the error message or null.</returns>
        public string Validate()
        {
            // name cannot be empty
            if (String.IsNullOrEmpty(Title))
            {
                return "Name cannot be empty.";
            }

            if (Length < 0)
            {
                return "Length must be >= 0.";
            }
            return null;
        }


        private string _title;
        private string _description;
    }
}

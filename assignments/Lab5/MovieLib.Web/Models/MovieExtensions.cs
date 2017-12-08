// Trey Kreis
// ITSE 1430
// December 7, 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLib.Web.Models 
{
    public static class ProductExtensions {
        /// <summary>Converts a <see cref="Movie"/> to a <see cref="MovieViewModel"/>.</summary>
        /// <param name="source">The movie.</param>
        /// <returns>The model.</returns>
        public static IEnumerable<MovieViewModel> ToModel(this IEnumerable<Movie> source)
        {
            foreach (var item in source)
                yield return item.ToModel();
            //return from item in source
            //       select item.ToModel();
        }

        /// <summary>Converts a <see cref="Movie"/> to a <see cref="MovieViewModel"/>.</summary>
        /// <param name="source">The movie.</param>
        /// <returns>The model.</returns>
        public static MovieViewModel ToModel(this Movie source)
        {
            return new MovieViewModel() {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                Length = source.Length,
                IsOwned = source.IsOwned
            };
        }

        /// <summary>Converts a <see cref="MovieViewModel"/> to a <see cref="Movie"/>.</summary>
        /// <param name="source">The model.</param>
        /// <returns>The movie.</returns>
        public static Movie ToDomain(this MovieViewModel source)
        {
            return new Movie() {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                Length = source.Length,
                IsOwned = source.IsOwned
            };
        }
    }
}
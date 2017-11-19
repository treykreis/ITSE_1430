//Trey Kreis
//ITSE 1430
//October 26, 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib {
    public interface IMovieDatabase {

        /// <summary>Adds a movie</summary>
        /// <param name="movie">The movie to add</param>
        /// <returns>The added movie</returns>
        ///<exception cref="ArgumentNullException"><paramref name="product"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="product"/> is invalid.</exception>
        Movie Add(Movie movie);

        /// <summary>Gets a specific movie</summary>
        /// <param name="id">The movie's id</param>
        /// <returns>The movie, if it exists</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> must be greater than or equal to 0.</exception> 
        Movie Get(int id);

        /// <summary>Gets all the movies</summary>
        /// <returns>The movies</returns>
        IEnumerable<Movie> GetAll();

        /// <summary>Updates a movie </summary>
        /// <param name="updatedMovie">The updated movie</param>
        /// <returns>The movie</returns>
        /// <exception cref="ArgumentNullException"><paramref name="product"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="product"/> is invalid.</exception>
        /// <exception cref="Exception">Product not found.</exception>
        Movie Update(Movie updatedMovie);

        /// <summary>Removes a movie</summary>
        /// <param name="id">The movie to remove</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> must be greater than or equal to 0.</exception>
        void Remove(int id);

    }
}

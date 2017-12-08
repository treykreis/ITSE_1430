using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib {

    /// <summary>Provides a base implementation of <see cref="IMovieDatabase"/></summary>
    public abstract class MovieDatabase : IMovieDatabase {

        /// <summary>Adds a movie</summary>
        /// <param name="movie">The movie to add</param>
        /// <returns>The added movie</returns>
        ///<exception cref="ArgumentNullException"><paramref name="product"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="product"/> is invalid.</exception>
        public Movie Add(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie was null");

            ObjectValidator.Validate(movie);
            try
            {
                return AddCore(movie);
            }
            catch (Exception e)
            {
                throw new Exception("Add failed", e);
                //rethrow
                throw;
                //throw e;
            };
        }

        /// <summary>Gets a specific movie</summary>
        /// <returns>The movie, if it exists</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> must be greater than or equal to 0.</exception> 
        public Movie Get(int id)
        {
            // validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }

        /// <summary>Gets all the movies</summary>
        /// <returns>The movies</returns>
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        /// <summary>Removes a movie by id</summary>
        /// <param name="id">The id of the movie to remove</param>
        public void Remove(int id)
        {
            // validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            RemoveCore(id);
        }

        /// <summary>Updates a movie with new information</summary>
        /// <param name="updatedMovie">The updated movie</param>
        /// <returns>The updated movie</returns>
        public Movie Update(Movie updatedMovie)
        {
            //validation
            if (updatedMovie == null)
                throw new ArgumentNullException(nameof(updatedMovie), "Movie was null");

            ObjectValidator.Validate(updatedMovie);

            // get existting movie
            var existing = GetCore(updatedMovie.Id);
            if (existing == null)
                throw new Exception("Movie not found.");
            
            return UpdateCore(existing, updatedMovie);
        }

        /// <summary>Adds a movie.</summary>
        /// <param name="product">The movie to add.</param>
        /// <returns>The added movie.</returns>
        protected abstract Movie AddCore(Movie movie);

        /// <summary>Get a movie given its ID.</summary>
        /// <param name="id">The ID.</param>
        /// <returns>The movie, if any.</returns>
        protected abstract Movie GetCore(int id);

        protected abstract IEnumerable<Movie> GetAllCore();

        /// <summary>Removes a movie by id.</summary>
        /// <param name="id">The ID.</param>
        protected abstract void RemoveCore(int id);

        /// <summary>Updates a movie.</summary>
        /// <param name="existing">The existing movie.</param>
        /// <param name="newItem">The movie to update.</param>
        /// <returns>The updated movie.</returns>
        protected abstract Movie UpdateCore(Movie existing, Movie newMovie);
    }
}

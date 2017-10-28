//Trey Kreis
//ITSE 1430
//October 26, 2017

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Data.Memory {
    public class MovieDatabase : IMovieDatabase {

        /// <summary>Adds a movie</summary>
        /// <param name="movie">The movie to add</param>
        /// <returns>The added movie</returns>
        public Movie Add(Movie movie)
        {
            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            if (newMovie.Id <= 0)
                newMovie.Id = _nextId++;
            else if (newMovie.Id >= _nextId)
            {
                _nextId = newMovie.Id + 1;
            };

            return CopyMovie(newMovie);
        }

        /// <summary>Gets a specific movie</summary>
        /// <param name="id">The movie's ID</param>
        /// <returns>The movie if it exists</returns>
        public Movie Get(int id)
        {
            var movie = FindMovie(id);

            if (movie != null)
            {
                CopyMovie(movie);
                return movie;
            }
            else return null;
        }

        /// <summary>Gets all the movies</summary>
        /// <returns>The movies</returns>
        public IEnumerable<Movie> GetAll()
        {
            foreach (var movie in _movies)
                yield return CopyMovie(movie);
        }

        /// <summary>Updates the movie </summary>
        /// <param name="updatedMovie">The movie to update</param>
        /// <returns>The updated movie</returns>
        public Movie Update(Movie updatedMovie)
        {
            if (!ObjectValidator.TryValidate(updatedMovie, out var errors))
                return null;

            var existing = FindMovie(updatedMovie.Id);
            _movies.Remove(existing);

            if (existing == null)
                return null;

            var newMovie = CopyMovie(updatedMovie);
            _movies.Add(newMovie);

            return CopyMovie(newMovie);
        }

        private Movie CopyMovie (Movie movie)
        {
            if (movie == null)
                return null;
            var newMovie = new Movie();
            newMovie.Title = movie.Title;
            newMovie.Id = movie.Id;
            newMovie.Description = movie.Description;
            newMovie.Length = movie.Length;
            newMovie.IsOwned = movie.IsOwned;

            return newMovie;
        }

        private Movie FindMovie (int id)
        {
            foreach (var movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            };
            return null;
        }

        /// <summary>Removes a movie </summary>
        /// <param name="id">The movie's ID to remove</param>
        public void Remove(int id)
        {
            if (id <= 0)
                return;

            var movie = FindMovie(id);
            if (movie != null)
                _movies.Remove(movie);
        }


        private List<Movie> _movies = new List<Movie>();
        private int _nextId = 1;
    }
}

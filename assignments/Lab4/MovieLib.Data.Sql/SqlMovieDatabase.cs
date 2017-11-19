// Trey Kreis
// ITSE 1430
// November 16, 2017

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Data.Sql
{

    /// <summary>Implements <see cref="IMovieDatabase"/> using a SQL server</summary>
    public class SqlMovieDatabase : MovieDatabase 
    {
        //constructor
        public SqlMovieDatabase (string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        protected override Movie AddCore(Movie movie)
        {
            var id = 0;
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("AddMovie", connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@title", movie.Title);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@length", movie.Length);
                cmd.Parameters.AddWithValue("@isOwned", movie.IsOwned);

                id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return GetCore(id);
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            var movies = new List<Movie>();
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("GetAllMovies", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = new Movie() {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Length = reader.GetInt32(3),
                            IsOwned = reader.GetBoolean(4)
                        };
                        movies.Add(movie);
                    }
                }
                return movies;
            }
        }

        protected override Movie GetCore(int id)
        {
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("GetMovie", connection) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Length = reader.GetInt32(3),
                            IsOwned = reader.GetBoolean(4)
                        };
                    }
                }
            }

            return null;
        }

        protected override void RemoveCore(int id)
        {
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("RemoveMovie", connection) { CommandType = CommandType.StoredProcedure };

                var parameter = new SqlParameter("@id", id);
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
            }
        }

        protected override Movie UpdateCore(Movie existing, Movie newMovie)
        {
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("UpdateMovie", connection) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@title", newMovie.Title);
                cmd.Parameters.AddWithValue("@description", newMovie.Description);
                cmd.Parameters.AddWithValue("@length", newMovie.Length);
                cmd.Parameters.AddWithValue("@isOwned", newMovie.IsOwned);

                cmd.ExecuteNonQuery();
            }

            return GetCore(existing.Id);
        }

        private SqlConnection OpenDatabase()
        {
            var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection;
        }
    }
}

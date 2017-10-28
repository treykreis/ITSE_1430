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
        Movie Add(Movie movie);
        Movie Get(int id);
        IEnumerable<Movie> GetAll();
        Movie Update(Movie updatedMovie);
        void Remove(int id);

    }
}

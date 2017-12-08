//Trey Kreis
//ITSE 1430
//October 26, 2017

using System;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib.Windows {
    public partial class MainForm : Form {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _miFileExit.Click += (o, ea) => Close();

            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"].ConnectionString;
            _database = new MovieLib.Data.Sql.SqlMovieDatabase(connString);

            _gridMovies.AutoGenerateColumns = false;
            UpdateList();
        }

        private void OnFileExit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnMovieAdd(object sender, EventArgs e)
        {
            var child = new MovieDetailForm();
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _database.Add(child.Movie);
            }
            catch (ValidationException ex)
            {
                DisplayError(ex, "Validation Failed");
            }
            catch (Exception ex)
            {
                DisplayError(ex, "Add Failed");
            };
            UpdateList();
        }

        private void OnMovieEdit(object sender, EventArgs e)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show("No movies available.");
                return;
            }
            EditMovie(movie);
        }

        private void EditMovie(Movie movie)
        {
            var child = new MovieDetailForm();
            child.Movie = movie;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            _database.Update(child.Movie);
            UpdateList();
        }

        private void OnMovieDelete(object sender, EventArgs e)
        {
            var movie = GetSelectedMovie();
            
            // check if there is a movie to delete
            if (movie == null)
            {
                MessageBox.Show(this, "There is no movie to delete.", "Error", MessageBoxButtons.OK);
                return;
            }

            // confirmation box
            if (MessageBox.Show(this, $"Are you sure you want to delete '{movie.Title}'?", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            _database.Remove(movie.Id);
            UpdateList();
        }

        private Movie GetSelectedMovie()
        {
            if (_gridMovies.SelectedRows.Count > 0)
                return _gridMovies.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private void OnEditRow(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Movie;

            if (item != null)
                EditMovie(item);
        }

        private void OnKeyDownGrid(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var movie = GetSelectedMovie();
            if (movie != null)
                DeleteMovie(movie);

            //Don't continue with key
            e.SuppressKeyPress = true;
        }
        
        private void DeleteMovie(Movie movie)
        {
            //Confirmation
            if (MessageBox.Show(this, $"Are you sure you want to delete '{movie.Title}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Delete the movie
            try
            {
                _database.Remove(movie.Id);
            }
            catch (Exception e)
            {
                DisplayError(e, "Delete Failed");
            };
            UpdateList();
        }

        private void UpdateList()
        {
            _bsMovies.DataSource = _database.GetAll().ToList();
        }

        private void OnHelpAbout(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        private IMovieDatabase _database;

        private void DisplayError(Exception error, string title = "Error")
        {
            DisplayError(error.Message, title);
        }

        private void DisplayError(string message, string title = "Error")
        {
            MessageBox.Show(this, message, title ?? "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

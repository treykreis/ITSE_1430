//Trey Kreis
//ITSE 1430
//October 7, 2017


using System;
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

        private void OnFileExit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnMovieAdd(object sender, EventArgs e)
        {
            var child = new MovieDetailForm();
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            _movie = child.Movie;
        }

        private void OnMovieEdit(object sender, EventArgs e)
        {
            var child = new MovieDetailForm();
            child.Movie = _movie;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;
            _movie = child.Movie;
        }

        private void OnMovieDelete(object sender, EventArgs e)
        {
            // check if there is a movie to delete
            if (_movie == null)
            {
                MessageBox.Show(this, "There is no movie to delete.", "Error", MessageBoxButtons.OK);
                return;
            }

            // confirmation box
            if (MessageBox.Show(this, $"Are you sure you want to delete '{_movie.Title}'?", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            _movie = null;
        }

        private void OnHelpAbout(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        private Movie _movie;
    }
}

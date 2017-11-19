//Trey Kreis
//ITSE 1430
//October 26, 2017


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
    public partial class MovieDetailForm : Form {
        public MovieDetailForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Movie != null)
            {
                _txtTitle.Text = Movie.Title;
                _txtDescription.Text = Movie.Description;
                _txtLength.Text = Movie.Length.ToString();
                _chkOwned.Checked = Movie.IsOwned;
            }
            ValidateChildren();
        }

        /// <summary>Gets or sets the movie </summary>
        public Movie Movie { get; set; }

        private void ShowError(string message, string title)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            };

            var movie = new Movie();
            movie.Id = Movie?.Id ?? 0;
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Length = GetLength(_txtLength);
            movie.IsOwned = _chkOwned.Checked;

            if (!ObjectValidator.TryValidate(movie, out var errors))
            {
                ShowError("Not Valid", "Validation Error");
                return;
            }

            Movie = movie;
            this.DialogResult = DialogResult.OK;
            Close();

        }

        private int GetLength(TextBox textbox)
        {
            if (int.TryParse(textbox.Text, out int length))
                return length;

            return -1;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ValidatingPrice(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;

            if (GetLength(tb) < 0)
            {
                e.Cancel = true;
                Errors.SetError(_txtLength, "Price must be >= 0.");
            }
            else
                Errors.SetError(_txtLength, "");
        }

        private void OnValidatingName(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            if (String.IsNullOrEmpty(tb.Text))
                Errors.SetError(tb, "Name is required");
            else
                Errors.SetError(tb, "");
        }
    }
}

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

        public Movie Movie { get; set; }

        private void OnSave(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            };

            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Length = GetLength(_txtLength);
            movie.IsOwned = _chkOwned.Checked;

            string error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                MessageBox.Show(this, error, "validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}

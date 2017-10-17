using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile {
    public partial class ProductDetailForm : Form {

        #region Contructors
        //constructor chaining
        public ProductDetailForm() //: base()
        {
            InitializeComponent();
        }
        public ProductDetailForm(string title) :this()
        {
            Text = title;
        }
        public ProductDetailForm( string title, Product product ) :this(title)
        {
            Product = product;
        }
        #endregion
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            if (Product != null)
            {
                _txtName.Text = Product.Name;
                _txtDescription.Text = Product.Description;
                _txtPrice.Text = Product.Price.ToString();
                _chkDiscontinued.Checked = Product.IsDiscontinued;
            }
            ValidateChildren();
        }

        /// <summary>Gets or sets the product being shown</summary>
        public Product Product { get; set; }
        private void ProductDetailForm_Load( object sender, EventArgs e )
        {

        }

        private void checkBox1_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void OnCancel( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError (string message, string title)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
            {
                return;
            };
            //var product = new Product();
            //product.Id = Product?.Id ?? 0;
            //product.Name = _txtName.Text;
            //product.Description = _txtDescription.Text;
            //product.Price = GetPrice(_txtPrice);
            //product.IsDiscontinued = _chkDiscontinued.Checked;

            // Object initializer syntax
            var product = new Product() {
                Id = Product?.Id ?? 0,
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                Price = GetPrice(_txtPrice),
                IsDiscontinued = _chkDiscontinued.Checked,
            };

            if (!ObjectValidator.TryValidate(product, out var errors))
            {
                //show the error.
                ShowError("Not Valid", "Validation Error");
                return;
            };

            Product = product;
            this.DialogResult = DialogResult.OK;
            
            Close();
        }

        private decimal GetPrice(TextBox control)
        {
            if (Decimal.TryParse(control.Text, out decimal price))
                return price;

            //TODO: validate price
            return -1;
        }

        private void ProductDetailForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            var form = sender as Form;
            if (MessageBox.Show(this, "Are you sure?", "Closing", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void ProductDetailForm_FormClosed( object sender, FormClosedEventArgs e )
        {

        }

        private void ValidatingPrice( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;

            if (GetPrice(tb) < 0)
            {
                e.Cancel = true;
                Errors.SetError(_txtPrice, "Price must be >= 0.");
            } else
                Errors.SetError(_txtPrice, "");
        }

        private void OnValidatingName( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;
            if (String.IsNullOrEmpty(tb.Text))
                Errors.SetError(tb, "Name is required");
            else
                Errors.SetError(tb, "");
        }
    }

    // load -> first render. only once
    //FormClosing, and then FormClosed
    //FormClosing -> pre close. still on the screen. can be cancelled
    //if not cancelled, it's gone. FormClosed -> post close. can do cleanup
}

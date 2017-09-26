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
        public ProductDetailForm()
        {
            InitializeComponent();
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

        private void OnSave( object sender, EventArgs e )
        {
            var product = new Product();
            product.Name = _txtName.Text;
            product.Description = _txtDescription.Text;

            product.Price = GetPrice();
            product.IsDiscontinued = _chkDiscontinued.Checked;

            //TODO: add validation

            Product = product;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private decimal GetPrice()
        {
            if (Decimal.TryParse(_txtPrice.Text, out decimal price))
                return price;

            //TODO: validate price
            return 0;
        }
    }
}

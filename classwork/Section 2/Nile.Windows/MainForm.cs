using System;
using System.Windows.Forms;

namespace Nile.Windows {
    public partial class MainForm : Form {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var child = new ProductDetailForm();
            child.Product = _product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;
            //TODO: save product
            _product = child.Product;
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm();
            if (child.ShowDialog(this) != DialogResult.OK)
                return;
            //TODO: save product
            _product = child.Product;
        }

        private void OnProductDelete( object sender, EventArgs e )
        {
            if (_product == null)
                return;

            // confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{_product.Name}'?", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //TODO: delete product
            _product = null;
        }
        private void OnHelpAbout( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        private Product _product;


        public delegate void ButtonClickCall( object sender, EventArgs e );

        private void CallButton (ButtonClickCall functionToCall)
        {
            functionToCall(this, EventArgs.Empty);
        }
    }
}

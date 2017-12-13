using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Nile.Stores;
using Nile.Stores.Sql;

namespace Nile.Windows {
    public partial class MainForm : Form {
        public MainForm()
        {
            InitializeComponent();
            
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);
            _miFileExit.Click += ( o, ev ) => Close();

            var connString = ConfigurationManager.ConnectionStrings["ProductDatabase"].ConnectionString;
            _database = new Nile.Stores.Sql.SqlProductDatabase(connString);
            //ProductDatabaseExtensions.WithSeedData(_database);
            _database.WithSeedData();

            _gridProducts.AutoGenerateColumns = false;
            UpdateList();
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            }
            EditProduct(product);
        }

        private void EditProduct( Product product )
        {
            var child = new ProductDetailForm();
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: save product
            _database.Update(child.Product);
            UpdateList();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {

            var child = new ProductDetailForm();
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //save product
            _database.Add(child.Product);
            UpdateList();
        }

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            }

            DeleteProduct(product);
        }

        private void DeleteProduct( Product product )
        {
            // confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            _database.Remove(product.Id);
            UpdateList();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        private Product GetSelectedProduct()
        {
            // return _listProducts.SelectedItem as Product;
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        public void UpdateList()
        {
            //new BindingList<Product>();
            
            _bsProducts.DataSource = _database.GetAll().ToList();
            //_listProducts.Items.Clear();
            //foreach (var product in _database.GetAll())
            //{
            //    _listProducts.Items.Add(product);
            //}
        }

        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            if (e.RowIndex < 0)
                return;
            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                 EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);

            e.SuppressKeyPress = true;

        }

        private IProductDatabase _database;
    }
}

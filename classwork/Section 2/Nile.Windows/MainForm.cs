﻿using System;
using System.Windows.Forms;

namespace Nile.Windows {
    public partial class MainForm : Form {
        public MainForm()
        {
            InitializeComponent();
            
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            var products = _database.GetAll();
        }

        /*private int FindAvailableElement()
        {
            for (var index = 0; index < _products.Length; ++index)
            {
                if (_products[index] == null)
                    return index;
            };

            return -1;
        }

        private int FindFirstProduct()
        {
            for (var index = 0; index < _products.Length; ++index)
            {
                if (_products[index] != null)
                    return index;
            };

            return -1;
        }*/

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = _database.Get();

            var child = new ProductDetailForm();
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: save product
            _database.Update(child.Product);
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm();
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //save product
            _database.Add(child.Product);
        }

        private void OnProductDelete( object sender, EventArgs e )
        {
           
            var product = _database.Get();

            // confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //TODO: delete product
            _database.Remove(product);
        }
        private void OnHelpAbout( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        private ProductDatabase _database = new ProductDatabase();


        /*public delegate void ButtonClickCall( object sender, EventArgs e );

        private void CallButton (ButtonClickCall functionToCall)
        {
            functionToCall(this, EventArgs.Empty);
        }*/
    }
}

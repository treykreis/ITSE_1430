using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile {

    /// <summary>Base class for product database.</summary>
    public class ProductDatabase 
    {
        public ProductDatabase()
        {
            _products[0] = new Product();
            _products[0].Name = "very fast car";
            _products[0].Price = 66666;

            _products[1] = new Product();
            _products[1].Name = "Bird";
            _products[1].Price = 100;
            _products[1].IsDiscontinued = true;

            _products[2] = new Product();
            _products[2].Name = "Bird 2";
            _products[2].Price = 4000;


        }

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add (Product product)
        {
            //TODO: implement add()
            return product;
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product if it exists</returns>
        public Product Get ()
        {
            //TODO: implement get()
            return null;
        }

        /// <summary>Gets all products. </summary>
        /// <returns>The products.</returns>
        public Product[] GetAll()
        {
            var items = new Product[_products.Length];
            var index = 0;
            foreach (var product in _products)
            {
                items[index++] = CopyProduct(product);
            };
            return items;
        }

        /// <summary>Updates the product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update(Product product)
        {
            //TODO: implement update
            return product;
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        public void Remove (Product product)
        {
            //TODO: implement remove
        }

        private Product CopyProduct (Product product)
        {
            if (product == null)
                return null;
            var newProduct = new Product();
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.IsDiscontinued = product.IsDiscontinued;

            return newProduct;
        }

        private Product[] _products = new Product[100];
    }
}

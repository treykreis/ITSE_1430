using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile {

    /// <summary>Base class for product database.</summary>
    public class ProductDatabase 
    {
        public ProductDatabase()
        {
            //_products.Add(new Product() {Id = 1, Name = "very fast car", Price = 66666, });
            //_products.Add(new Product() {Id = 2, Name = "Bird", Price = 100, IsDiscontinued = true, });
            //_products.Add(new Product() {Id = 3, Name = "Bird 2", Price = 4000, });

            //Collection initializer syntax
            _products = new List<Product>() {
                new Product() { Id = 1, Name = "very fast car", Price = 66666, },
                new Product() { Id = 2, Name = "Bird", Price = 100, IsDiscontinued = true, },
                new Product() { Id = 3, Name = "Bird 2", Price = 4000, },
            };

            //Collection initializer syntax with array
            //_products.AddRange(new [] {
            //    new Product() { Id = 1, Name = "very fast car", Price = 66666, },
            //    new Product() { Id = 2, Name = "Bird", Price = 100, IsDiscontinued = true, },
            //    new Product() { Id = 3, Name = "Bird 2", Price = 4000, },
            //});

            _nextId = _products.Count + 1;
        }

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add (Product product)
        {
            // TODO: Validate
            if (product == null)
                return null;

            if (!ObjectValidator.TryValidate(product, out var errors))
                return null;
            //if (!String.IsNullOrEmpty(product.Validate()))
            //    return null;

            // emulate database by storing copy
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);
            newProduct.Id = _nextId++;

            //var item = _list[0];
            return CopyProduct(newProduct);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product if it exists</returns>
        public Product Get (int id)
        {
            //TODO: Validate
            if (id <= 0)
                return null;

            var product = FindProduct(id);

            return (product != null) ? CopyProduct(product) : null;
        }

        /// <summary>Gets all products. </summary>
        /// <returns>The products.</returns>
        public Product[] GetAll()
        {
            var items = new Product[_products.Count];
            var index = 0;
            foreach (var product in _products)
                items[index++] = CopyProduct(product);

            return items;
            // how many products?
            //var count = 0;
            //foreach(var product in _products)
            //{
            //    if (product != null)
            //        ++count;
            //}

            //var items = new Product[count];
            //var index = 0;
            //foreach (var product in _products)
            //{
            //    if (product != null)
            //        items[index++] = CopyProduct(product);
            //};
            //return items;

       
        }

        /// <summary>Updates the product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update(Product product)
        {
            if (product == null)
                return null;
            if (!ObjectValidator.TryValidate(product, out var errors))
                return null;

            // get existing product
            var existing = FindProduct(product.Id);
            if (existing == null)
                return null;

            // Replace
            _products.Remove(existing);

            // emulate database by storing copy
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);
            
            //var item = _list[0];
            return CopyProduct(newProduct);
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        public void Remove (int id)
        {
            if (id <= 0)
                return;

            var product = FindProduct(id);
            if (product != null)
                _products.Remove(product);
        }

        private Product CopyProduct (Product product)
        {
            if (product == null)
                return null;
            var newProduct = new Product();
            newProduct.Id = product.Id;
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.IsDiscontinued = product.IsDiscontinued;

            return newProduct;
        }

        // Find a product by ID
        private Product FindProduct (int id)
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        //private Product[] _products = new Product[100];
        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
    }
}

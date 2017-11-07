﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores {

    /// <summary>Base class for product database.</summary>
    public class MemoryProductDatabase : ProductDatabase {


        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore (Product product)
        {
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            if (newProduct.Id <= 0)
                newProduct.Id = _nextId++;
            else if (newProduct.Id >= _nextId)
            {
                _nextId = newProduct.Id + 1;
            };

            return CopyProduct(newProduct);
        }
        
        /// <summary>Get a specific product.</summary>
        /// <returns>The product if it exists</returns>
        protected override Product GetCore (int id)
        {
            var product = FindProduct(id);

            return (product != null) ? CopyProduct(product) : throw new Exception("Product not in memory");
            
        }

        /// <summary>Gets all products. </summary>
        /// <returns>The products.</returns>
        protected override IEnumerable<Product> GetAllCore()
        {
            //foreach (var product in _products)
            //    yield return CopyProduct(product);

            return from item in _products
                   select CopyProduct(item);
        }

        /// <summary>Updates the product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore(Product existing, Product product)
        {
            // Replace
            existing = FindProduct(product.Id);
            _products.Remove(existing);
            
            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            return CopyProduct(newProduct);
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore (int id)
        {
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
            newProduct.Description = product.Description;
            newProduct.IsDiscontinued = product.IsDiscontinued;

            return newProduct;
        }

        // Find a product by ID
        private Product FindProduct (int id)
        {
            //foreach (var product in _products)
            //{
            //    if (product.Id == id)
            //        return product;
            //};
            //return null;

            return (from product in _products
                    where product.Id == id
                    select product).FirstOrDefault();

            // LINQ conversion syntax
            //return _products.Where(p => p.Id == id)
            //                .Select(p => p)
            //                .FirstOrDefault();
        }

        //private Product[] _products = new Product[100];
        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
    }
}

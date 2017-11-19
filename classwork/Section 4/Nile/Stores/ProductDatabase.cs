using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores {

    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase {
        public ProductDatabase()
        {
            
        }

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        /// <exception cref="ArgumentNullException">Product is null</exception>"
        /// <exception cref="ValidationException">Product is invalid</exception>"
        public Product Add (Product product)
        {
            // TODO: Validate
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product was null");

            ObjectValidator.Validate(product);

            //if (!ObjectValidator.TryValidate(product, out var errors))
            //    throw new ValidationException("Product is not valid" );
            return AddCore(product);
        }
        protected abstract Product AddCore( Product product );

        /// <summary>Get a specific product.</summary>
        /// <returns>The product if it exists</returns>
        public Product Get (int id)
        {
            //TODO: Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be > 0");

            return GetCore(id);
        }

        protected abstract Product GetCore( int id );

        /// <summary>Gets all products. </summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll()
        {
            return GetAllCore();
        }

        protected abstract IEnumerable<Product> GetAllCore();

        /// <summary>Updates the product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product was null");

            ObjectValidator.Validate(product);

            // get existing product
            var existing = GetCore(product.Id) ?? throw new Exception("Product not found");
           // if (existing == null)
           //     throw new Exception("Product not found");

            return UpdateCore(existing, product);
        }

        protected abstract Product UpdateCore(Product existing, Product newItem);

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        public void Remove (int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be > 0");

            RemoveCore(id);
        }

        protected abstract void RemoveCore( int id );
    }
}

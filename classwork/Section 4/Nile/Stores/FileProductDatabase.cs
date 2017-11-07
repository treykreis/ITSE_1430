using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores {

    /// <summary>Base class for product database.</summary>
    public class FileProductDatabase : MemoryProductDatabase {

        public FileProductDatabase (string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentException("Filename cannot be empty", nameof(fileName));

            _filename = fileName;

            LoadFile(fileName);
        }

        private void LoadFile( string fileName )
        {
            if (!File.Exists(fileName))
                return;
            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line))
                    continue;

                var fields = line.Split(',');
                var product = new Product() {
                    Id = Int32.Parse(fields[0]),
                    Name = fields[1],
                    Description = fields[2],
                    Price = Decimal.Parse(fields[3]),
                    IsDiscontinued = Boolean.Parse(fields[4])
                };

                base.AddCore(product);
            };

        }

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore (Product product)
        {
            var newProduct = base.AddCore(product);

            SaveFile(_filename);

            return newProduct;
        }

        private void SaveFile( string filename )
        {
            //Streaming
            //StreamWriter writer = null;
            //var stream = File.OpenWrite(filename);
            //try
            //{
            //    // write stuff
            //    writer = new StreamWriter(stream);
            //} finally
            //{
            //    writer?.Dispose();
            //    stream.Close();
            //};

            using (var writer = new StreamWriter(filename))
            {
                foreach (var product in GetAllCore())
                {
                    var row = String.Join(",", product.Id, product.Name, product.Description, 
                                          product.Price, product.IsDiscontinued);

                    writer.WriteLine(row);
                }
            };
        }

        /// <summary>Updates the product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore(Product existing, Product product)
        {
            var newProduct = base.UpdateCore(existing, product);

            SaveFile(_filename);

            return newProduct;
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore (int id)
        {
            base.RemoveCore(id);

            SaveFile(_filename);
        }

        private readonly string _filename;
    }
}

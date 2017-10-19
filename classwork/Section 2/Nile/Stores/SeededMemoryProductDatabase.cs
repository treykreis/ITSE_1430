using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores {

    /// <summary>Base class for product database.</summary>
    public class SeededMemoryProductDatabase : MemoryProductDatabase {
        public SeededMemoryProductDatabase()
        {
            //_products.Add(new Product() {Id = 1, Name = "very fast car", Price = 66666, });
            //_products.Add(new Product() {Id = 2, Name = "Bird", Price = 100, IsDiscontinued = true, });
            //_products.Add(new Product() {Id = 3, Name = "Bird 2", Price = 4000, });


            AddCore(new Product() { Id = 1, Name = "very fast car", Price = 66666, });
            AddCore(new Product() { Id = 2, Name = "Bird", Price = 100, IsDiscontinued = true, });
            AddCore(new Product() { Id = 3, Name = "Bird 2", Price = 4000, });

            //Collection initializer syntax with array
            //_products.AddRange(new [] {
            //    new Product() { Id = 1, Name = "very fast car", Price = 66666, },
            //    new Product() { Id = 2, Name = "Bird", Price = 100, IsDiscontinued = true, },
            //    new Product() { Id = 3, Name = "Bird 2", Price = 4000, },
            //});
        }
    }
       
}

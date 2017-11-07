using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile {

    /// <summary>Base class for product database.</summary>
    public static class ProductDatabaseExtensions {
        public static void WithSeedData(this IProductDatabase source)
        {
            // extension method
            source.Add(new Product() { Name = "very fast car", Price = 66666, });
            source.Add(new Product() { Name = "Bird", Price = 100, IsDiscontinued = true, });
            source.Add(new Product() { Name = "Bird 2", Price = 4000, });

            //use cases for extension methods
            //no type access
            //expose instance functionality
            //needs to be useful or isolated
            //do not extend primitaves
            //extending interfaces

            //Collection initializer syntax with array
            //_products.AddRange(new [] {
            //    new Product() { Id = 1, Name = "very fast car", Price = 66666, },
            //    new Product() { Id = 2, Name = "Bird", Price = 100, IsDiscontinued = true, },
            //    new Product() { Id = 3, Name = "Bird 2", Price = 4000, },
            //});
        }

        public static Product GetByName(this IProductDatabase source, string name)
        {
            foreach(var item in source.GetAll())
            {
                if (string.Compare(item.Name, name, true) == 0)
                    return item;
            };

            return null;
        }
    }
       
}

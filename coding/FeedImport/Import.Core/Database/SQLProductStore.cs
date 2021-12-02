using Import.Core.Contracts;
using Import.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Import.Core.Database
{
	public class SQLProductStore : IProductStore
    {
        private void Log(Product product)
        {
            var cat = product.Categories.Select(c => c.Name);
            Console.WriteLine($"importing: Name: \"{ product.Name }\"; Categories: { string.Join(", ", cat) };  Twitter: @{product.TwitterHandle}");
        }

		public void StoreProduct(IEnumerable<Product> products)
		{
			foreach (var product in products)
			{
				Log(product);
			}
		}
	}
}

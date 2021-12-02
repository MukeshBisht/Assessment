using Import.Core.Models;
using System.Collections.Generic;

namespace Import.Core.Contracts
{
	public interface IProductStore
    {
        /// <summary>
        /// Store the Product
        /// </summary>
        /// <param name="product">The Product</param>
        /// <returns>Created Product Id</returns>
        void StoreProduct(IEnumerable<Product> products);
    }
}

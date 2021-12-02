using Import.Core.Models;
using System.Collections.Generic;

namespace Import.Core.Contracts
{
    public interface IProvider
    {
        /// <summary>
        /// Get the Product Feed
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetFeed();
    }
}

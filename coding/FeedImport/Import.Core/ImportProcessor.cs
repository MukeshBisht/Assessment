using Import.Core.Contracts;
using Import.Core.Exceptions;

namespace Import.Core
{
	public class ImportProcessor
    {
        private readonly IProvider _provider;
        private readonly IProductStore _store;

        public ImportProcessor(IProvider provider, IProductStore store)
        {
            _provider = provider;
            _store = store;
        }

        /// <summary>
        /// Get feed from provder and store
        /// </summary>
        public void Import()
        {
            try
            {
                var feed = _provider.GetFeed();
                _store.StoreProduct(feed);
            }
            catch(ImportException ex)
			{
				System.Console.WriteLine("import failed.");
				System.Console.WriteLine(ex.Message);
			}
        }
    }
}

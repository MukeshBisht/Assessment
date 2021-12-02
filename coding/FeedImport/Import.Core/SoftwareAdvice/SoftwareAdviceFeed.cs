using Import.Core.Contracts;
using Import.Core.Exceptions;
using Import.Core.Models;
using Import.Core.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Import.Core.SoftwareAdvice
{
	public partial class SoftwareAdviceFeed : IProvider
    {
        private readonly IFeedReader<Stream, SoftwareAdviceFeedModel> _feedReader;
        private readonly string _path;

        public SoftwareAdviceFeed(string path)
        {
            _feedReader = new JsonStreamFeedReader<SoftwareAdviceFeedModel>();
            _path = path;
        }

        public IEnumerable<Product> GetFeed()
        {
            try
            {
                List<Product> products = new List<Product>();
                using (FileStream fs = File.OpenRead(_path))
                {
                    var feed = _feedReader.Read(fs);
                    return feed.Products.Select(item =>
                         new Product()
                         {
                             Name = item.Title,
                             TwitterHandle = item.Twitter?.Trim('@'),
                             Categories = MapCategories(item.Categories)
                         }
                     );
                }
            }
            catch (Exception ex)
            {
                throw new ImportException($"can't read file {_path}.", ex);
            }
        }

        private List<Category> MapCategories(List<string> categories)
            => categories?.Select(c => new Category(c)).ToList();
    }
}

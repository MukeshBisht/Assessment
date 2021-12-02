using Import.Core.Contracts;
using Import.Core.Exceptions;
using Import.Core.Models;
using Import.Core.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Import.Core.Capterra
{
	public partial class CapterraFeed : IProvider
    {
        private readonly IFeedReader<Stream, IEnumerable<CapterraFeedModel>> _feedReader;
        private readonly string _path;

        public CapterraFeed(string path)
        {
            _feedReader = new YamlStreamFeedReader<IEnumerable<CapterraFeedModel>>();
            _path = path;
        }

        public IEnumerable<Product> GetFeed()
        {
            try
            {
                using (FileStream fs = File.OpenRead(_path))
                {
                    var feed = _feedReader.Read(fs);
                    return feed.Select(item =>
                         new Product()
                         {
                             Name = item.Name,
                             TwitterHandle = item.Twitter,
                             Categories = MapCategories(item.Tags)
                         }
                     );
                }
			}
			catch(Exception ex)
			{
                throw new ImportException($"can't read file {_path}.", ex);
			}
        }

        private List<Category> MapCategories(string categoriesStr)
            => categoriesStr.Split(',').Select(c => new Category(c)).ToList();
    }
}

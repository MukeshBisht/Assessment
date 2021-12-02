using System.Collections.Generic;

namespace Import.Core.Models
{
    public class Product
    {
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public string TwitterHandle { get; set; }
    }
}

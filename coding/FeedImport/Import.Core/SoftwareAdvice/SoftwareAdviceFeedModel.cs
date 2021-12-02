using System.Collections.Generic;

namespace Import.Core.SoftwareAdvice
{
    internal class SoftwareAdviceFeedModel
    {
        public IEnumerable<FeedModel> Products { get; set; }

        internal class FeedModel
        {
            public string Title { get; set; }
            public string Twitter { get; set; }
            public List<string> Categories { get; set; }
        }
    }
}


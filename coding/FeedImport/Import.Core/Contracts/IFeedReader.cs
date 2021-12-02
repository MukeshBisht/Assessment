using System.Collections.Generic;

namespace Import.Core.Contracts
{
	public interface IFeedReader<Source, T>
    {
        /// <summary>
        /// Read Data from Source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        T Read(Source source);
    }
}

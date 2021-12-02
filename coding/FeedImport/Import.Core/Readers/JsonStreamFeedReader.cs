using Import.Core.Contracts;
using Import.Core.Exceptions;
using System;
using System.IO;
using System.Text.Json;

namespace Import.Core.Readers
{
	public class JsonStreamFeedReader<T> : IFeedReader<Stream, T>
    {
        public T Read(Stream source)
        {
            try
            {
                using (StreamReader reader = new StreamReader(source))
                {
                    string json = reader.ReadToEnd();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var data = JsonSerializer.Deserialize<T>(json, options);
                    return data;
                }
            }
            catch(Exception ex)
			{
                throw new ImportException($"failed read { typeof(T) } from stream.", ex);
			}
        }
    }

}

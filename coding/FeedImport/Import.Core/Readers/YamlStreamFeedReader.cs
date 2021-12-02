using Import.Core.Contracts;
using Import.Core.Exceptions;
using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Import.Core.Readers
{
    public class YamlStreamFeedReader<T> : IFeedReader<Stream, T>
    {
        public T Read(Stream source)
        {
            try
            {
                using (StreamReader reader = new StreamReader(source))
                {
                    string yaml = reader.ReadToEnd();
                    var yamlDeserializer = new DeserializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();
                    var data = yamlDeserializer.Deserialize<T>(yaml);
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new ImportException($"failed read { typeof(T) } from stream.", ex);
            }
        }
    }
}
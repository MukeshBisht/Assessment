using Import.Core.Exceptions;
using Import.Core.Readers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Import.Core.Tests
{
	public class YamlStreamReaderTests
	{
		[Theory]
		[InlineData("[1, 2, 3, 4, 5]", new int[] { 1,2,3,4,5 })]
		public void ReaderSuccessfullyParseWhenTypeMatchGivenYaml(string listOfIntYaml, int[] givenIntegers)
		{
			YamlStreamFeedReader<List<int>> reader = new YamlStreamFeedReader<List<int>>();
			using(Stream stream = GenerateStreamFromString(listOfIntYaml))
			{
				var integers = reader.Read(stream).ToArray();
				Assert.Equal(givenIntegers, integers);
			}
		}

		[Theory]
		[InlineData(@"items: [1,2,3,4]")]
		public void ReaderThrowsExceptionWhenTypeMismactchGivenYaml(string listOfIntYaml)
		{
			YamlStreamFeedReader<List<int>> reader = new YamlStreamFeedReader<List<int>>();
			using (Stream stream = GenerateStreamFromString(listOfIntYaml))
			{
				Assert.Throws<ImportException>(() => reader.Read(stream));
			}
		}

		private MemoryStream GenerateStreamFromString(string value)
		{
			return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
		}
	}
}

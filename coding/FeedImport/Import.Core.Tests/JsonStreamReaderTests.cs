using Import.Core.Exceptions;
using Import.Core.Readers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Import.Core.Tests
{
	public class JsonStreamReaderTests
	{
		[Theory()]
		[InlineData("[1, 2, 3, 4, 5]", new int[] { 1,2,3,4,5 })]
		[InlineData("[10, 12, 15]", new int[] { 10, 12, 15 })]
		public void ReaderSuccessfullyParseWhenTypeMatchGivenJson(string listOfIntJson, int[] givenIntegers)
		{
			JsonStreamFeedReader<List<int>> reader = new JsonStreamFeedReader<List<int>>();
			using(Stream stream = GenerateStreamFromString(listOfIntJson))
			{
				var integers = reader.Read(stream).ToArray();
				Assert.Equal(givenIntegers, integers);
			}
		}

		[Theory]
		[InlineData("{[1,2,3,4,5]}")]
		public void ReaderThrowsExceptionWhenTypeMismactchGivenJson(string listOfIntJson)
		{
			JsonStreamFeedReader<List<int>> reader = new JsonStreamFeedReader<List<int>>();
			using (Stream stream = GenerateStreamFromString(listOfIntJson))
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

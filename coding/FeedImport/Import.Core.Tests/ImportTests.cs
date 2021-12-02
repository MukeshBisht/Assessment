using Import.Core.Contracts;
using Import.Core.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Import.Core.Tests
{
	public class ImportTests
	{
		private readonly Mock<IProvider> a = new Mock<IProvider>();
		private readonly Mock<IProductStore> b = new Mock<IProductStore>();
		
		private ImportProcessor importProcessor;

		[Fact]
		public void RunningImportShouldGetFeedFromProvider()
		{
			// Arrange
			importProcessor = new ImportProcessor(a.Object, b.Object);
			SetupMocks();

			// Act
			importProcessor.Import();

			// Assert
			a.Verify(c=>c.GetFeed(), Times.Once());
		}

		[Fact]
		public void RunningImportShouldWriteFeedToDatabase()
		{
			// Arrange
			importProcessor = new ImportProcessor(a.Object, b.Object);
			SetupMocks();

			// Act
			importProcessor.Import();

			// Assert
			b.Verify(c => c.StoreProduct(It.IsAny<IEnumerable<Product>>()), Times.Once);
		}

		private void SetupMocks()
		{
			a.Setup(f => f.GetFeed()).Returns(GetProducts());
			b.Setup(f => f.StoreProduct(It.IsAny<IEnumerable<Product>>()));
		}

		private List<Product> GetProducts()
		{
			return new List<Product>()
			{
				new Product()
				{
					Name = "awesome product",
					TwitterHandle = "@awesome"
				}
			};
		}
	}
}

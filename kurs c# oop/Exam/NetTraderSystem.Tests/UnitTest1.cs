using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NetTraderSystem.Tests
{
	[TestFixture]
	public class TradingPlatformTests
	{
		private TradingPlatform tradingPlatform;
		private Product product1;
		private Product product2;

		[SetUp]
		public void Setup()
		{
			tradingPlatform = new TradingPlatform(10);
			product1 = new Product("Laptop", "Electronics", 999.99);
			product2 = new Product("Phone", "Electronics", 499.99);
		}

		[Test]
		public void AddProduct_ShouldAddProduct_WhenInventoryIsNotFull()
		{
			string result = tradingPlatform.AddProduct(product1);
			Assert.AreEqual("Product Laptop added successfully", result);
			Assert.Contains(product1, new List<Product>(tradingPlatform.Products));
		}

		[Test]
		public void AddProduct_ShouldReturnInventoryFull_WhenInventoryIsFull()
		{
			tradingPlatform = new TradingPlatform(1);
			tradingPlatform.AddProduct(product1);
			string result = tradingPlatform.AddProduct(product2);
			Assert.AreEqual("Inventory is full", result);
		}

		[Test]
		public void RemoveProduct_ShouldRemoveProduct_WhenProductExists()
		{
			tradingPlatform.AddProduct(product1);
			bool result = tradingPlatform.RemoveProduct(product1);
			Assert.IsTrue(result);
			Assert.IsFalse(new List<Product>(tradingPlatform.Products).Contains(product1));
		}

		[Test]
		public void RemoveProduct_ShouldReturnFalse_WhenProductDoesNotExist()
		{
			bool result = tradingPlatform.RemoveProduct(product1);
			Assert.IsFalse(result);
		}

		[Test]
		public void SellProduct_ShouldReturnProduct_WhenProductExists()
		{
			tradingPlatform.AddProduct(product1);
			Product result = tradingPlatform.SellProduct(product1);
			Assert.AreEqual(product1, result);
			Assert.IsFalse(new List<Product>(tradingPlatform.Products).Contains(product1));
		}

		[Test]
		public void SellProduct_ShouldReturnNull_WhenProductDoesNotExist()
		{
			Product result = tradingPlatform.SellProduct(product1);
			Assert.IsNull(result);
		}

		[Test]
		public void InventoryReport_ShouldReturnCorrectReport()
		{
			tradingPlatform.AddProduct(product1);
			tradingPlatform.AddProduct(product2);

			string report = tradingPlatform.InventoryReport();
			StringBuilder expectedReport = new StringBuilder();
			expectedReport.AppendLine("Inventory Report:");
			expectedReport.AppendLine("Available Products: 2");
			expectedReport.AppendLine("Name: Laptop, Category: Electronics - $999.99");
			expectedReport.AppendLine("Name: Phone, Category: Electronics - $499.99");
			Assert.AreEqual(expectedReport.ToString().TrimEnd(), report);
		}
	}
}

using ProductService.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Entities;
using System.Threading.Tasks;
using ProductService.Application.QueryHandlers;
using NUnit.Framework;
using MongoDB.Bson;

namespace ProductService.Application.Tests.Unit.QueryHandlers
{
    public class GetProductQueryHandlerTests : BaseProductTest
    {

        [Test]
        public async Task Should_ReturnValidProductDTO_WhenQueryIsValid()
        {
            var productName = Guid.NewGuid().ToString();
            var testProduct = new Product()
            {
                Active = true,
                ModifiedOn = DateTime.Now,
                Name = productName,
                Price = 15
            };

            await testProduct.SaveAsync();

            var handler = new GetProductQueryHandler();
            var result = await handler.Handle(new Queries.GetProductQuery()
            {
                ProductId = testProduct.ID
            }, default);

            Assert.NotNull(result);
            Assert.AreEqual(productName, result.Name);
            Assert.AreEqual(15, result.Price);
            Assert.IsTrue(result.Active);
        }

        [Test]
        public async Task Should_ThrowFormatException_WhenQueryIsInvalid()
        {
            var productName = Guid.NewGuid().ToString();
            var testProduct = new Product()
            {
                Active = true,
                ModifiedOn = DateTime.Now,
                Name = productName,
                Price = 15
            };

            await testProduct.SaveAsync();

            var handler = new GetProductQueryHandler();
            var testQuery = new Queries.GetProductQuery()
            {
                ProductId = "test"
            };

            Assert.ThrowsAsync<FormatException>(async () => await handler.Handle(testQuery, default));
        }

        [Test]
        public async Task Should_ThrowArguementException_WhenRecordNotFound()
        {
            var productName = Guid.NewGuid().ToString();
            var testProduct = new Product()
            {
                Active = true,
                ModifiedOn = DateTime.Now,
                Name = productName,
                Price = 15
            };

            await testProduct.SaveAsync();

            var handler = new GetProductQueryHandler();
            var testQuery = new Queries.GetProductQuery()
            {
                ProductId = ObjectId.GenerateNewId().ToString()
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await handler.Handle(testQuery, default));
        }
    }
}

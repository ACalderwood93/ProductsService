using MongoDB.Entities;
using NUnit.Framework;
using ProductService.Application.CommandHandlers;
using ProductService.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace ProductService.Application.Tests.Unit.CommandHandlers
{
    public class CreateProductCommandHandlerTests : BaseProductTest
    {
        [Test]
        public async Task Should_ReturnTrue_When_ValidCreateProductCommandGiven()
        {
            var handler = new CreateProductCommandHandler();
            var testName = Guid.NewGuid().ToString();

            var result = await handler.Handle(new Commands.CreateProductCommand
            {
                Active = true,
                Name = testName,
                Price = 100

            }, default);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task Should_ReturnFalse_When_ActiveIsNull()
        {
            var handler = new CreateProductCommandHandler();
            var testName = Guid.NewGuid().ToString();

            var result = await handler.Handle(new Commands.CreateProductCommand
            {
                Active = null,
                Name = testName,
                Price = 100

            }, default);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task Should_ReturnFalse_When_PriceIsNull()
        {
            var handler = new CreateProductCommandHandler();
            var testName = Guid.NewGuid().ToString();

            var result = await handler.Handle(new Commands.CreateProductCommand
            {
                Active = true,
                Name = testName,
                Price = null

            }, default);

            Assert.IsFalse(result);
        }
    }
}

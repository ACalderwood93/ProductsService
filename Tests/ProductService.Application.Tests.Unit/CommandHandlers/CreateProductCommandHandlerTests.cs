using NUnit.Framework;
using ProductService.Application.CommandHandlers;
using System;
using System.Threading.Tasks;
namespace ProductService.Application.Tests.Unit.CommandHandlers
{
    public class CreateProductCommandHandlerTests : BaseProductTest
    {
        [Test]
        public async Task Should_ReturnNewId_When_ValidCreateProductCommandGiven()
        {
            var handler = new CreateProductCommandHandler();
            var testName = Guid.NewGuid().ToString();

            var result = await handler.Handle(new Commands.CreateProductCommand
            {
                Active = true,
                Name = testName,
                Price = 100

            }, default);

            Assert.IsNotEmpty(result);
        }

        [Test]
        public void Should_ThrowArguementException_When_ActiveIsNull()
        {
            var handler = new CreateProductCommandHandler();
            var testName = Guid.NewGuid().ToString();
            var command = new Commands.CreateProductCommand
            {
                Active = null,
                Name = testName,
                Price = 100

            };
            Assert.ThrowsAsync<ArgumentException>(async () => await handler.Handle(command, default));


        }

        [Test]
        public void Should_ThrowArguementException_When_PriceIsNull()
        {
            var handler = new CreateProductCommandHandler();
            var testName = Guid.NewGuid().ToString();
            var command = new Commands.CreateProductCommand
            {
                Active = true,
                Name = testName,
                Price = null

            };

            Assert.ThrowsAsync<ArgumentException>(async () => await handler.Handle(command, default));
        }
    }
}

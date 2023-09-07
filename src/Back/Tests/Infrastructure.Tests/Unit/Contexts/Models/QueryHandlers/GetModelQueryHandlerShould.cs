using Api;
using Application.Contexts.Models.Commands.Handlers;
using Application.Contexts.Models.Queries;
using Client.Abstractions.DTOs.Models;
using FluentAssertions;
using Infrastructure.OpenAi.Clients.Abstractions;
using Moq;
using Tests.Core;

namespace Infrastructure.Tests.Unit.Contexts.Models.QueryHandlers
{
    [TestFixture(Category = "Unit")]
	internal class GetModelQueryHandlerShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_model()
		{
			// Arrange
			var client = new Mock<IOpenAiClient>();
			client.Setup(client => client.GetModel(ModelId))
				.ReturnsAsync(OpenAiModel);

			var handler = new GetModelQueryHandler(Mapper, client.Object);

			// Act
			var response = await handler.Handle(new GetModelQuery(ModelId), CancellationToken.None);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<ModelDTO>();
		}
	}
}

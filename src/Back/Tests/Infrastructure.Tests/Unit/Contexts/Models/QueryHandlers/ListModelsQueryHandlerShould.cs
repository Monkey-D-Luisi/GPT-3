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
	internal class ListModelsQueryHandlerShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_models_list()
		{
			// Arrange
			var client = new Mock<IOpenAiClient>();
			client.Setup(client => client.ListModels())
				.ReturnsAsync(OpenAiModels);

			var handler = new ListModelsQueryHandler(Mapper, client.Object);

			// Act
			var response = await handler.Handle(new ListModelsQuery(), CancellationToken.None);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<IEnumerable<ModelDTO>>();
		}
	}
}

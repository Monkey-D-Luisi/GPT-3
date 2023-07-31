using Api;
using Application.Contexts.Models.Commands.Handlers;
using Application.Contexts.Models.Queries;
using Domain.Common.Clients;
using Domain.Common.DTOs;
using FluentAssertions;
using Moq;
using Tests.Core;

namespace Infrastructure.Tests.Unit.Contexts.Models.QueryHandlers
{
	[TestFixture(Category = "Unit")]
	internal class ListModelsQueryHandlerShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_moq_response_asking_for_models()
		{
			// Arrange
			var client = new Mock<IOpenAiClient>();
			client.Setup(client => client.ListModels())
				.ReturnsAsync(Models);

			var handler = new ListModelsQueryHandler(client.Object);

			// Act
			var response = await handler.Handle(new ListModelsQuery(), CancellationToken.None);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<IEnumerable<OpenAiModelDTO>>();
		}
	}
}

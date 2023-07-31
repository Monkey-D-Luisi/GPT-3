using Api;
using Application.Contexts.Models.Commands.Handlers;
using Application.Contexts.Models.Queries;
using Client.Abstractions.DTOs.Models;
using Domain.Common.Clients;
using FluentAssertions;
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
				.ReturnsAsync(Model);

			var handler = new GetModelQueryHandler(client.Object);

			// Act
			var response = await handler.Handle(new GetModelQuery(ModelId), CancellationToken.None);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<ModelDTO>();
		}
	}
}

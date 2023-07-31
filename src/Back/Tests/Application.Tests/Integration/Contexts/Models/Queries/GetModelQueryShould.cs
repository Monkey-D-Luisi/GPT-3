using Api;
using Application.Contexts.Models.Queries;
using Client.Abstractions.DTOs.Models;
using FluentAssertions;
using Tests.Core;

namespace Application.Tests.Integration.Contexts.Models.Queries
{
	[TestFixture(Category = "Integration")]
	internal class GetModelQueryHandlerShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_models_list()
		{
			// Arrange
			var query = new GetModelQuery(ModelId);

			// Act
			var response = await Mediator.Send<ModelDTO>(query, CancellationToken.None);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<ModelDTO>();
		}
	}
}

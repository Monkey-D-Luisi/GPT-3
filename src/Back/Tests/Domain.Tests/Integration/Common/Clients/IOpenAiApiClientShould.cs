using Api;
using Domain.Common.Clients;
using Domain.Common.DTOs;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Tests.Core;

namespace Domain.Tests.Integration.Common.Clients
{
	[TestFixture(Category = "Integration")]
	internal class IOpenAiApiClientShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_response_from_OpenAi_client_asking_for_models()
		{
			// Arrange
			var client = WebApplicationFactory.Services.GetRequiredService<IOpenAiClient>();

			// Act
			var response = await client.ListModels();

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<IEnumerable<OpenAiModelDTO>>();
		}
	}
}

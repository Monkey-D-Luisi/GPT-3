using Api;
using Domain.Common.DTOs;
using FluentAssertions;
using Infrastructure.Common.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tests.Core;

namespace Infrastructure.Tests.Integration.Common.Clients
{
	[TestFixture(Category = "Integration")]
	internal class HttpOpenAiApiClientShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_response_from_OpenAi_client_asking_for_models()
		{
			// Arrange
			var config = WebApplicationFactory.Services.GetRequiredService<IConfiguration>();
			var serviceProvider = WebApplicationFactory.Services.GetRequiredService<IServiceProvider>();
			var client = new HttpOpenAiClient(serviceProvider, config);

			// Act
			var response = await client.ListModels();			

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<IEnumerable<OpenAiModelDTO>>();
		}
	}
}

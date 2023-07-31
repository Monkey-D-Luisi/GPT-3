using Api;
using Domain.Common.DTOs;
using FluentAssertions;
using Flurl.Http.Testing;
using Infrastructure.Contexts.Models.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tests.Core;

namespace Infrastructure.Tests.Unit.Contexts.Models.Services
{
	[TestFixture(Category = "Unit")]
	internal class ListModelsServiceShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_moq_response_asking_for_models()
		{
			// Arrange
			using var httpTest = new HttpTest();
			httpTest.RespondWithJson(new { data = Models });

			var config = WebApplicationFactory.Services.GetRequiredService<IConfiguration>();
			var client = new ListModelsService(config);

			// Act
			var response = await client.ListModels(ApiHost, ApiKey);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<IEnumerable<OpenAiModelDTO>>();
		}
	}
}

using Api;
using FluentAssertions;
using Flurl.Http.Testing;
using Infrastructure.Contexts.Models.Services.Abstractions;
using Infrastructure.Contexts.Models.Services.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Tests.Core;

namespace Domain.Tests.Unit.Contexts.Models.Services
{
	[TestFixture(Category = "Unit")]
	internal class IListModelsServiceShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_models_list()
		{
			// Arrange
			using var httpTest = new HttpTest();
			httpTest.RespondWithJson(new { data = OpenAiModels });

			var client = WebApplicationFactory.Services.GetRequiredService<IListModelsService>();

			// Act
			var response = await client.ListModels(ApiHost, ApiKey);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<IEnumerable<OpenAiModelDTO>>();
		}
	}
}

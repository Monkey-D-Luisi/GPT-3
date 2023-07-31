using Api;
using Domain.Common.DTOs;
using Domain.Contexts.Models.Services;
using FluentAssertions;
using Flurl.Http.Testing;
using Microsoft.Extensions.DependencyInjection;
using Tests.Core;

namespace Domain.Tests.Unit.Contexts.Models.Services
{
	[TestFixture(Category = "Unit")]
	internal class IListModelsServiceShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_moq_response_asking_for_models()
		{
			// Arrange
			using var httpTest = new HttpTest();
			httpTest.RespondWithJson(new { data = Models });

			var client = WebApplicationFactory.Services.GetRequiredService<IListModelsService>();

			// Act
			var response = await client.ListModels(ApiHost, ApiKey);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<IEnumerable<OpenAiModelDTO>>();
		}
	}
}

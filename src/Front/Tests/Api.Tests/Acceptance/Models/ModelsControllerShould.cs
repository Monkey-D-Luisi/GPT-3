using Client.Abstractions.DTOs.Models;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using Tests.Core;

namespace Api.Tests.Acceptance.Models
{
	[TestFixture(Category = "Acceptance")]
	internal class ListModelsQueryHandlerShould : TestBase<Program>
	{


		[Test]
		public async Task List_models()
		{
			// Arrange

			// Act
			var response = await WebApplicationClient.GetAsync($"v1/models");
			var content = await response.Content.ReadFromJsonAsync<IEnumerable<ModelDTO>>();

			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			content.Should().NotBeNull();
			content.Should().BeAssignableTo<IEnumerable<ModelDTO>>();
		}


		[Test]
		public async Task Get_a_model()
		{
			// Arrange

			// Act
			var response = await WebApplicationClient.GetAsync($"v1/models/{ModelId}");
			var content = await response.Content.ReadFromJsonAsync<ModelDTO>();

			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			content.Should().NotBeNull();
			content.Should().BeAssignableTo<ModelDTO>();
		}
	}
}

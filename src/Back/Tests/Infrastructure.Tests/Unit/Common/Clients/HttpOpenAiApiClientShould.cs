using Api;
using Domain.Common.DTOs;
using Domain.Contexts.Models.Services;
using FluentAssertions;
using Infrastructure.Common.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Tests.Core;

namespace Domain.Tests.Unit.Common.Clients
{
	[TestFixture(Category = "Unit")]
	internal class IOpenAiApiClientShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_moq_response_asking_for_models()
		{
			// Arrange
			var listModelsServiceMock = new Mock<IListModelsService>();
			listModelsServiceMock.Setup(service => service.ListModels(ApiHost, ApiKey))
				.ReturnsAsync(Models);
			var configMock = new Mock<IConfiguration>();
			configMock.Setup(config => config.GetSection("OpenAi:Api:HttpHost").Value).Returns(ApiHost);
			configMock.Setup(config => config.GetSection("OpenAi:Api:Key").Value).Returns(ApiKey);
			var serviceProviderMock = new Mock<IServiceProvider>();
			serviceProviderMock.Setup(provider => provider.GetService(typeof(IListModelsService)))
				.Returns(listModelsServiceMock.Object);

			var client = new HttpOpenAiClient(serviceProviderMock.Object, configMock.Object);

			// Act
			var response = await client.ListModels();

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<IEnumerable<OpenAiModelDTO>>();
		}
	}
}

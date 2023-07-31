using Api;
using Client.Abstractions.DTOs.Models;
using FluentAssertions;
using Infrastructure.Common.Clients;
using Infrastructure.Contexts.Models.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Moq;
using Tests.Core;

namespace Domain.Tests.Unit.Common.Clients
{
	[TestFixture(Category = "Unit")]
	internal class IOpenAiApiClientShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_models_list()
		{
			// Arrange
			var listModelsServiceMock = new Mock<IListModelsService>();
			listModelsServiceMock.Setup(service => service.ListModels(ApiHost, ApiKey))
				.ReturnsAsync(OpenAiModels);
			var configMock = new Mock<IConfiguration>();
			configMock.Setup(config => config.GetSection("OpenAi:Api:HttpHost").Value).Returns(ApiHost);
			configMock.Setup(config => config.GetSection("OpenAi:Api:Key").Value).Returns(ApiKey);
			var serviceProviderMock = new Mock<IServiceProvider>();
			serviceProviderMock.Setup(provider => provider.GetService(typeof(IListModelsService)))
				.Returns(listModelsServiceMock.Object);

			var client = new HttpOpenAiClient(serviceProviderMock.Object, Mapper, configMock.Object);

			// Act
			var response = await client.ListModels();

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<IEnumerable<ModelDTO>>();
		}


		[Test]
		public async Task Get_a_model()
		{
			// Arrange
			var getModelServiceMock = new Mock<IGetModelService>();
			getModelServiceMock.Setup(service => service.GetModel(ModelId, ApiHost, ApiKey))
				.ReturnsAsync(OpenAiModel);
			var configMock = new Mock<IConfiguration>();
			configMock.Setup(config => config.GetSection("OpenAi:Api:HttpHost").Value).Returns(ApiHost);
			configMock.Setup(config => config.GetSection("OpenAi:Api:Key").Value).Returns(ApiKey);
			var serviceProviderMock = new Mock<IServiceProvider>();
			serviceProviderMock.Setup(provider => provider.GetService(typeof(IGetModelService)))
				.Returns(getModelServiceMock.Object);

			var client = new HttpOpenAiClient(serviceProviderMock.Object, Mapper, configMock.Object);

			// Act
			var response = await client.GetModel(ModelId);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<ModelDTO>();
		}
	}
}

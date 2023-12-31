﻿using Api;
using FluentAssertions;
using Infrastructure.OpenAi.Clients.Abstractions;
using Infrastructure.OpenAi.Contexts.Models.Services.DTOs;
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


		[Test]
		public async Task Get_a_response_from_OpenAi_client_asking_for_a_model()
		{
			// Arrange
			var client = WebApplicationFactory.Services.GetRequiredService<IOpenAiClient>();

			// Act
			var response = await client.GetModel(ModelId);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<OpenAiModelDTO>();
		}
	}
}

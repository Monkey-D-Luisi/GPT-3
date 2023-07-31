﻿using Api;
using Domain.Common.DTOs;
using Domain.Contexts.Models.Services;
using FluentAssertions;
using Flurl.Http.Testing;
using Microsoft.Extensions.DependencyInjection;
using Tests.Core;

namespace Domain.Tests.Unit.Contexts.Models.Services
{
	[TestFixture(Category = "Unit")]
	internal class IGetModelServiceShould : TestBase<Program>
	{


		[Test]
		public async Task Get_a_model()
		{
			// Arrange
			using var httpTest = new HttpTest();
			httpTest.RespondWithJson(new { data = Model });

			var client = WebApplicationFactory.Services.GetRequiredService<IGetModelService>();

			// Act
			var response = await client.GetModel(ModelId, ApiHost, ApiKey);

			// Assert
			response.Should().NotBeNull();
			response.Should().BeAssignableTo<OpenAiModelDTO>();
		}
	}
}

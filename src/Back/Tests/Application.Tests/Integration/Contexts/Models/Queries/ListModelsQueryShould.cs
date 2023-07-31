using Api;
using Application.Contexts.Models.Queries;
using Domain.Common.DTOs;
using FluentAssertions;
using Tests.Core;

namespace Application.Tests.Integration.Contexts.Models.Queries
{
	[TestFixture(Category = "Integration")]
    internal class ListModelsQueryHandlerShould : TestBase<Program>
    {


        [Test]
        public async Task Get_a_models_list()
        {
            // Arrange
            var query = new ListModelsQuery();

			// Act
			var response = await Mediator.Send<IEnumerable<OpenAiModelDTO>>(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Should().BeAssignableTo<IEnumerable<OpenAiModelDTO>>();
        }
    }
}

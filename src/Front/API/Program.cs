using Application.Contexts.Models.Commands.Handlers;
using Infrastructure.OpenAi.Clients;
using Infrastructure.OpenAi.Clients.Abstractions;
using Infrastructure.OpenAi.Contexts.Models.Services;
using Infrastructure.OpenAi.Contexts.Models.Services.Abstractions;
using System.Reflection;

namespace Api;
public class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.AddScoped<IOpenAiClient, HttpOpenAiClient>();
		builder.Services.AddSingleton<IListModelsService, ListModelsService>();
		builder.Services.AddSingleton<IGetModelService, GetModelService>();

		builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssembly(typeof(ListModelsQueryHandler).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(Infrastructure.OpenAi.Contexts.Models.Queries.Handlers.ListModelsQueryHandler).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(GetModelQueryHandler).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(Infrastructure.OpenAi.Contexts.Models.Queries.Handlers.GetModelQueryHandler).Assembly);
			});

		builder.Services.AddAutoMapper(Assembly.Load("Infrastructure"));

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
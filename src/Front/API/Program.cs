using Application.Contexts.Models.Commands.Handlers;
using Domain.Common.Clients;
using Domain.Contexts.Models.Services;
using Infrastructure.Common.Clients;
using Infrastructure.Contexts.Models.Services;

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

		builder.Services.AddTransient<IOpenAiClient, HttpOpenAiClient>();
		builder.Services.AddSingleton<IListModelsService, ListModelsService>();
		builder.Services.AddSingleton<IGetModelService, GetModelService>();

		builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssembly(typeof(ListModelsQueryHandler).Assembly);
				cfg.RegisterServicesFromAssembly(typeof(GetModelQueryHandler).Assembly);
			});

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
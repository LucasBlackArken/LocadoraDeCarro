using LocadoraDeCarro.Application.Validator.Carro;
using LocadoraDeCarro.Domain.Interfaces;
using LocadoraDeCarro.Domain.Repository;
using LocadoraDeCarro.IdentityServer;
using LocadoraDeCarro.Infrastructure.Context;
using LocadoraDeCarro.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FluentValidation;
using MediatR;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Builder;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container
		builder.Services.AddControllers();

		// Swagger
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(c =>
		{
			c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
			{
				Type = SecuritySchemeType.OAuth2,
				Flows = new OpenApiOAuthFlows
				{
					ClientCredentials = new OpenApiOAuthFlow
					{
						TokenUrl = new Uri("https://localhost:5001/connect/token"),
						Scopes = { { "locadora_api", "Acesso a Locadora de Carro API" } }
					}
				}
			});
			c.OperationFilter<SecurityRequirementsOperationFilter>();
		});

        // DbContext
        builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        // Repositories
        builder.Services.AddScoped<ICarroRepository, CarroRepository>();
		builder.Services.AddScoped<IAluguelRepository, AluguelRepository>();

		// MediatR
		builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

		// FluentValidation
		builder.Services.AddValidatorsFromAssemblyContaining<CadastrarCarroCommandValidator>();


		// IdentityServer4
		builder.Services
		.AddIdentityServer()
		.AddInMemoryIdentityResources(Config.IdentityResources)
		.AddInMemoryApiScopes(Config.ApiScopes)
		.AddInMemoryApiResources(Config.ApiResources)
		.AddInMemoryClients(Config.Clients)
		.AddDeveloperSigningCredential();


		// Authentication
		builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.Authority = "https://localhost:7275";
					options.RequireHttpsMetadata = true;
					options.Audience = "locadora_api";
				});

		builder.Services.AddCors(options =>
		{
			options.AddPolicy("AllowAll", policy =>
			{
				policy
						.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
			});
		});




		var app = builder.Build();

		// Middleware pipeline
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Locadora API v1");
                c.OAuthClientId("locadora_client");
                c.OAuthClientSecret("super_senha");
                c.OAuthScopes("locadora_api");
            });

        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("AllowAll");
        app.UseIdentityServer();
		app.UseAuthentication();
		app.UseAuthorization();
		app.MapControllers();
		app.Run();
	}
}
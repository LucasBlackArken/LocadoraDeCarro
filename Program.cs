using LocadoraDeCarro.Application.Validator.Carro;
using LocadoraDeCarro.Domain.Interfaces;
using LocadoraDeCarro.Domain.Repository;
using LocadoraDeCarro.IdentityServer;
using LocadoraDeCarro.Infrastructure.Context;
using LocadoraDeCarro.Utils;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // DbContext
        builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString(Utils.ConnectionString)));

        // Repositories
        builder.Services.AddScoped<ICarroRepository, CarroRepository>();
        builder.Services.AddScoped<IAluguelRepository, AluguelRepository>();

        //// MediatR
        //builder.Services.AddMediatR(typeof(Program));

        //// FluentValidation
        //builder.Services.AddValidatorsFromAssemblyContaining<CadastrarCarroCommandValidator>();

        //// IdentityServer4
        //builder.Services
        //    .AddIdentityServer()
        //    .AddInMemoryIdentityResources(Config.IdentityResources)
        //    .AddInMemoryApiScopes(Config.ApiScopes)
        //    .AddInMemoryClients(Config.Clients)
        //    .AddDeveloperSigningCredential();

        //// Authentication
        //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddJwtBearer(opt =>
        //    {
        //        opt.Authority = "https://localhost:5001";
        //        opt.RequireHttpsMetadata = true;
        //        opt.Audience = "locadora_api";
        //    });

        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen(c =>
        //{
        //    c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        //    {
        //        Type = Microsoft.OpenApi.Models.SecuritySchemeType.OAuth2,
        //        Flows = new Microsoft.OpenApi.Models.OpenApiOAuthFlows
        //        {
        //            ClientCredentials = new Microsoft.OpenApi.Models.OpenApiOAuthFlow
        //            {
        //                TokenUrl = new Uri("https://localhost:5001/connect/token"),
        //                Scopes = { { "locadora_api", "Acesso a Locadora de Carro API" } }
        //            }
        //        }
        //    });
        //    c.OperationFilter<Swashbuckle.AspNetCore.Filters.SecurityRequirementsOperationFilter>();
        //});



        var app = builder.Build();
        // Middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("locadora_client");
                c.OAuthClientSecret("super_senha");
                c.OAuthScopes("locadora_api");
            });
        }

        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
using LocadoraDeCarro.Domain.Interfaces;
using LocadoraDeCarro.Domain.Repository;
using LocadoraDeCarro.IdentityServer;
using LocadoraDeCarro.Infrastructure.Context;
using LocadoraDeCarro.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAluguelRepository, AluguelRepository>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
		options.UseNpgsql(builder.Configuration.GetConnectionString(Utils.ConnectionString)));

// IdentityServer
builder.Services.AddIdentityServer()
		.AddInMemoryIdentityResources(Config.IdentityResources)
		.AddInMemoryApiScopes(Config.ApiScopes)
		.AddInMemoryClients(Config.Clients)
		.AddTestUsers(Config.Users)
		.AddDeveloperSigningCredential(); // apenas para desenvolvimento



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

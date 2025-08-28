using Microsoft.Extensions.Options;
using Mint.API.Options;
using Mint.Application.Interfaces;
using Mint.Application.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<MongoDatabaseOptions>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var options = serviceProvider.GetRequiredService<IOptions<MongoDatabaseOptions>>().Value;
    return new MongoClient(options.ConnectionString);
});

builder.Services.AddScoped(serviceProvider =>
{
    var options = serviceProvider.GetRequiredService<IOptions<MongoDatabaseOptions>>().Value;
    var client = serviceProvider.GetRequiredService<IMongoClient>();
    return client.GetDatabase(options.Database);
});

// Register Transaction Service
builder.Services.AddScoped<ITransactionService, TransactionService>();

// Adding Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

public partial class Program { }

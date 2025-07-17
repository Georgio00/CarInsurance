using MongoDB.Driver;
using PolicyManagment.Application;
using PolicyManagment.Infrastructure;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container with proper JSON options for enums and case-insensitivity
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // Case-insensitive property binding
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)); // Enum as camelCase strings
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB setup
var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");
var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase("CarInsurance");

builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);

// Register the MongoPolicyDataAccess as IPolicyDataAccess
builder.Services.AddScoped<IPolicyDataAccess, MongoPolicyDataAccess>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

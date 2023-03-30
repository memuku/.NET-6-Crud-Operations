using CrudExample;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System;
using MongoDB.Bson;
using static CrudExample.MongoDBController;
using CrudExample.Settings;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.Configure<MongoDbSettings>(Configuration.GetSection(MongoDbSettings.DefaultSectionName));
builder.Services.AddSingleton<IDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);


builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var connectionString = builder.Configuration.GetConnectionString("mongodb://localhost:27017/muvekkil");
    return new MongoClient(connectionString);
});
builder.Services.AddScoped(serviceProvider =>
{
    var mongoClient = serviceProvider.GetService<IMongoClient>();
    var databaseName = serviceProvider.GetService<IOptions<DatabaseSettings>>().Value.DatabaseName;
    IMongoClient mongoClient1 = new MongoClient("mongodb://localhost:27017/");
    IMongoDatabase db = mongoClient1.GetDatabase("muvekkil-mongo-db");
    IMongoCollection<User> collection = db.GetCollection<User>("Users");
    return mongoClient.GetDatabase(databaseName);
});

// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "User API", Version = "v1" });
});

// Add controllers and configure routing
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API v1"));
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();

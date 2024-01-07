using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PatikaAkbankBookstore.DbOperations;
using PatikaAkbankBookstore.Middlewares;
using PatikaAkbankBookstore.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreDbContext>(options=>options.UseInMemoryDatabase(databaseName:"BookStoreDB"));
builder.Services.AddScoped<IBookStoreDbContext>(provider => provider.GetService<BookStoreDbContext>());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<PatikaAkbankBookstore.Services.ILogger, ConsoleLogger>();


var app = builder.Build();

using ( var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomEsceptionMiddle();

app.MapControllers();

app.Run();

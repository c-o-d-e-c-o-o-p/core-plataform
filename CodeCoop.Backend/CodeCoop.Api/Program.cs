using CodeCoop.Api.EndPoints;
using CodeCoop.Application.Interfaces;
using CodeCoop.Application.UseCases;
using CodeCoop.Infrastructure.Notion.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITrailRepository, NotionTrailService>();
builder.Services.AddScoped<GetAllTrailsUseCase>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureTrailEndpoints();
app.Run();


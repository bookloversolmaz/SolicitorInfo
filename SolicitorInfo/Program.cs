using SolicitorInfo.Models;
using SolicitorInfo.Repository;
using SolicitorInfo.Scrapers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<SolicitorContext>(opt =>
    opt.UseInMemoryDatabase("Solicitor"));
builder.Services.AddScoped<ISolicitorRepository,
                                SolicitorRepository>();
builder.Services.AddScoped<IScrapingService,
                            ScrapingService>();

builder.Services.AddHttpClient<SolicitorScraper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

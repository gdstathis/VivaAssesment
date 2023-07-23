using Country.DataAccess.CacheMemoryConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using NLog.Web;
using SecondMaxFinderLibrary;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SecondMaxFinder>();
builder.Services.AddMvc().AddNewtonsoftJson();
builder.Services.AddDbContext<Country.DataAccess.Database.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<Country.DataAccess.Repository.IUnitOfWork, Country.DataAccess.Repository.UnitOfWork>();
builder.Services.AddScoped<ICacheMemoryConfig, CacheMemoryConfig>();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
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

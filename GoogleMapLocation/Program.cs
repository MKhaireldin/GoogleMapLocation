using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddDbContext<RepositoryContext>(
    optionsAction => 
    optionsAction.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b=>b.MigrationsAssembly("GoogleMapLocation")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

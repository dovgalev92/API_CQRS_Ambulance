using Microsoft.EntityFrameworkCore;
using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Infrastructure.EfCore;
using Ambulance_API_CQRS.Services;
using System.Reflection;
using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using MediatR;
using Ambulance_API_CQRS.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddProfile(new AssemblyMappingProfiles(Assembly.GetExecutingAssembly())));
builder.Services.AddApplication();


builder.Services.AddDbContext<IApplicationDb, ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectSqlServer")));
//DIServices
builder.Services.AddRepository();


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

using Microsoft.EntityFrameworkCore;
using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Infrastructure.EfCore;
using Ambulance_API_CQRS.Services;
using System.Reflection;
using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using MediatR;
using Ambulance_API_CQRS.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfiles(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfiles(typeof(IApplicationDb).Assembly));
});


builder.Services.AddApplication();


builder.Services.AddDbContext<IApplicationDb, ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectSqlServer")));
//DIServices
builder.Services.AddRepository();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(o => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

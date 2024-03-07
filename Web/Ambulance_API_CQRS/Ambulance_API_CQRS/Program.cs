using Microsoft.EntityFrameworkCore;
using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Infrastructure.EfCore;
using Ambulance_API_CQRS.Services;
using System.Reflection;
using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using Ambulance_API_CQRS.Application;
using Ambulance_API_CQRS.DIServices;
using NLog;



var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

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
builder.Services.ConfigureLoggerServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(o => { });

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

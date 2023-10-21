using Microsoft.EntityFrameworkCore;
using WebApi.Project.Application;
using WebApi.Project.Application.Service;
using WebApi.Project.Domain;
using WebApi.Project.Domain.Entity;
using WebApi.Project.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// build cac tang 
ApplicationConfig.Config(builder.Services);
DomainConfig.Config(builder.Services);
InfrastructureConfig.Config(builder.Services);
builder.Services.AddDbContext<EmployeedbContext>( o => o.UseMySql(builder.Configuration.GetConnectionString("apicon") , ServerVersion.Parse("8.0.34-mysql")) );

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

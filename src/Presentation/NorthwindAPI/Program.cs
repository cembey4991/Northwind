using System.Reflection;
using Application.Abstractions.Services;
using Application.Features.Queries.GetAllProduct;
using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Service;

var builder = WebApplication.CreateBuilder(args);
var assembliesToScan = new[]
{
    Assembly.GetExecutingAssembly(),
    Assembly.GetAssembly(typeof(GenericRepository<>)),
};

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
options=> options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// builder.Services.AddScoped<IProductService, ProductService>();
// builder.Services.AddScoped<IProductRepository, ProductRepository>();

//DI AutoRegistration
builder.Services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
.Where(c=>c.Name.EndsWith("Service")).AsPublicImplementedInterfaces();
builder.Services.RegisterAssemblyPublicNonGenericClasses()
.Where(c=>c.Name.EndsWith("Repository")).AsPublicImplementedInterfaces();
builder.Services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
    .Where(c => c.Name == "Handler");

//builder.Services.AddTransient<GetAllProductQueryHandler>();
builder.Services.AddMediatR(typeof(GetAllProductQueryRequest), typeof(GetAllProductQueryResponse));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
  app.UseSwaggerUI(c=>{c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");c.RoutePrefix = "";});

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

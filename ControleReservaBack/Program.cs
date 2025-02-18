using ControleReserva.Application.Service;
using ControleReserva.Application.Validator;
using ControleReserva.Domain.Interface;
using ControleReserva.Domain.Interface.Repository;
using ControleReserva.Domain.Interface.Service;
using ControleReserva.Infraestructure;
using ControleReserva.Infraestructure.Context;
using ControleReserva.Infraestructure.Repository;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ReservaValidator>(lifetime: ServiceLifetime.Transient));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<ISalaRepository, SalaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReservaContext>(op => op.UseNpgsql(builder.Configuration.GetConnectionString("Conexao")));
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

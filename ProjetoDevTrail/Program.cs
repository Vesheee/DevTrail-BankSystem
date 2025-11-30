using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjetoDevTrail.Application.services;
using ProjetoDevTrail.Domain.interfaces.repository;
using ProjetoDevTrail.Domain.interfaces.service;
using ProjetoDevTrail.Infra.Context;
using ProjetoDevTrail.Infra.Repositories;
using ProjetoDevTrail.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repositories e services
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();


builder.Services.AddScoped<IContaService, ContaAppService>();
builder.Services.AddScoped<IClienteService, ClienteAppService>();
builder.Services.AddScoped<ITransacaoService, TransacaoAppService>();

//Banco de dados
builder.Services.AddDbContext<BankContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BankDatabase")));

builder.Services.AddControllers();

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

app.MapGet("/Banco de Dados", async (BankContext context) =>
{

    try
    {
        bool conexaoOK = await context.Database.CanConnectAsync();
        if (conexaoOK)
        {
            return Results.Ok("O banco esta funcionando.");
        }
        else
        {
            return Results.Problem("N o foi poss vel conectar ao banco de dados.");
        }
    }
    catch (Exception ex)
    {
        return Results.Problem($"Meu banco falhou: {ex.Message}");
    }
});

app.Run();

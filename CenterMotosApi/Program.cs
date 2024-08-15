using CenterMotosApi.Data;
using CenterMotosApi.Repositories;
using CenterMotosApi.Repositories.Interfaces;
using CenterMotosApi.Repositories.UnitOfWork;
using CenterMotosApi.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Configurando a conexão com o banco de dados
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"));
});

// Configuração para uploads grandes
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 100_000_000; // Limite de tamanho de 100 MB para uploads
});

builder.Services.AddMvc();

// Configuração de CORS para permitir qualquer origem, método e cabeçalho
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
    {
        policy.WithOrigins("http://localhost:3000") //permite só no meu front nessa porta
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Registrando os serviços e repositórios no container de injeção de dependência
builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();
builder.Services.AddScoped<ICarrinhosRepository, CarrinhosRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IItemCarrinhosService, ItemCarrinhosService>();
builder.Services.AddScoped<IItemCarrinhosRepository, ItemCarrinhosRepository>();
builder.Services.AddScoped<IProdutosService, ProdutosService>();
builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicando a política de CORS que permite todas as origens, métodos e cabeçalhos
app.UseCors("AllowLocalhost3000");

app.UseAuthorization();
app.MapControllers();

app.Run();
//using controller_example.Controllers;
using Microsoft.Extensions.DependencyInjection;
using example_db.Data;
using animezz.MVC.controller;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

var context = new MyProjectDbContext();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://your-frontend-domain.com")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddSession(options =>
{
    // Configura��es de op��es de sess�o
    options.Cookie.Name = ".Animezz.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Define o tempo limite de inatividade da sess�o
    // Outras configura��es, se necess�rio
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("AllowSpecificOrigin"); // Usar a pol�tica correta para permitir credenciais
app.UseSession();

app.AdicionarControllersUsuario();
app.AdicionarControllersUsuarioSemLogin();
app.AdicionarControllersAdmin();

app.Run();

// LEMBRAR DE IMPLEMENTAR O CONCEITO DE PERFIL DE USU�RIO
// para verificar se o usu�rio logado tem acesso ao controller que ele tentou acessar

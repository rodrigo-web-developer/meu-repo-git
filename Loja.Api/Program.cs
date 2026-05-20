using Loja.Core.Data;
using Loja.Core.Services;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<CategoriaService>();

builder.Services.AddDbContext<LojaDbContext>();

Environment.SetEnvironmentVariable(
    "ConnectionStrings__DefaultConnection",
    "Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=loja");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(op => op.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
);

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.Data.SqlClient;
using System.Data;
using WebAPI_Carlos_Chica_20261112.Repository;
using WebAPI_Carlos_Chica_20261112.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conexion = builder.Configuration.GetConnectionString("Base_Conexion");


builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(conexion));

builder.Services.AddControllers();
builder.Services.AddScoped<ServiceVuelos>();
builder.Services.AddScoped<VuelosRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(op =>
{
    op.AddPolicy("PermitirAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("PermitirAngular");

app.MapControllers();

app.Run();

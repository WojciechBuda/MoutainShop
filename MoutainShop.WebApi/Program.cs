using Microsoft.EntityFrameworkCore;
using MoutainShop.Domain.Models;
using MoutainShopService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()     // zezwala wszystkim originom
              .AllowAnyMethod()     // zezwala na wszystkie metody HTTP
              .AllowAnyHeader();    // zezwala na wszystkie nag³ówki
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MoutainShopDbContext>(options =>
    options.UseInMemoryDatabase("MoutainShopDb"));

//builder.Services.AddTransient<ProductService>(); //transient - za ka¿dym u¿yciem jest tworzony nowy serwis
builder.Services.AddScoped<ProductService>(); //scoped - jest tworzony za ka¿dym http request
//builder.Services.AddSingleton<ProductService>(); //singleton - jest tworzony raz na odpalenie aplikacji (runtime)

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();




app.MapControllers();

app.Run();




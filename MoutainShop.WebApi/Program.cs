using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MoutainShop.Domain.Models;
using MoutainShop.WebApi;
using MoutainShopService;
using Microsoft.Identity.Web;


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
//autentykacja kim jestes a autoryzacja czy masz dostep
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddMicrosoftIdentityWebApi(options =>
                   {
                       builder.Configuration.Bind("AzureAD", options);

                       options.TokenValidationParameters.NameClaimType = "name";
                   }, options => { builder.Configuration.Bind("AzureAD", options); });

builder.Services.AddAuthorization(options =>
{
    var azureAdOptions = builder.Configuration
                            .GetSection("AzureAD")
                            .Get<ConfigurationSections.AzureAd>();
    // Create policy to check for the scope 'read'

    var scopes = azureAdOptions?.Scopes ?? string.Empty;

    options.AddPolicy("ReadWrite",
        policy => policy.Requirements.Add(new ScopesRequirement(scopes)));
});
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MoutainShopDbContext>(options =>
    options.UseInMemoryDatabase("MoutainShopDb"));

//builder.Services.AddTransient<ProductService>(); //transient - za ka¿dym u¿yciem jest tworzony nowy serwis
builder.Services.AddScoped<IProductService, ProductService>(); //scoped - jest tworzony za ka¿dym http request
//builder.Services.AddSingleton<ProductService>(); //singleton - jest tworzony raz na odpalenie aplikacji (runtime)

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapProductEndpoints();
// Configure the HTTP request pipeline.
app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.Run();




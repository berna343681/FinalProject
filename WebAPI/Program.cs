using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolves.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Core.Utilities.Security.JWT;
using Core.Utilities.IoC;
using Core.Extensions;
using Core.DependencyResolves;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Autofac kullanýmý
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new AutofacBusinessModule());
    });

// Swagger ayarlarý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.WithOrigins("http://localhost:5288", "http://localhost:4200", "http://localhost:42284", "http://localhost:25301", "http://localhost:26322")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});


// TokenOptions ayarlarý
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

// JWT ayarlarýný ekleyin
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
        };
    });

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

// ServiceTool kullanýmý
ServiceTool.Create(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


using System.Text;
using Microsoft.EntityFrameworkCore;
using GerenciadorFinanca.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using GerenciadorFinanca.Models;
using GerenciadorFinanca.Entidades;
using GerenciadorFinanca.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<APIContexto>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version("8.0.31")))
);


builder.Services.AddDefaultIdentity<AplicacaoUsuario>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<APIContexto>();




    //Configuração do JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          option.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = "API.Securiry.Bearer",
              ValidAudience = "API.Securiry.Bearer",
              IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-87654321")
          };

          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
          };
});



builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Gerenciador",
            Version = "v1"
            });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(opt =>{
            opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using System.Text;
using Microsoft.EntityFrameworkCore;
using GerenciadorFinanca.Data;
using Microsoft.AspNetCore.Identity;
using GerenciadorFinanca.Serviços;
using GerenciadorFinanca.Repositorio.IContratos;
using GerenciadorFinanca.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version("8.0.31")))
);


builder.Services.AddDefaultIdentity<IdentityUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApiContext>()
        .AddDefaultTokenProviders();


    //Configuração do JWT
var JwtConfigSection = builder.Configuration.GetSection("JwtConfig");
builder.Services.Configure<JwtConfig>(JwtConfigSection);

var jwtConfig = JwtConfigSection.Get<JwtConfig>();
var key = Encoding.ASCII.GetBytes(jwtConfig.Secreto);


builder.Services.AddAuthentication(a => {
    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(a => {
        a.RequireHttpsMetadata = true;
        a.SaveToken = true;
        a.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = jwtConfig.ValidoEm,
            ValidIssuer = jwtConfig.Emissor
        };

    });








builder.Services.AddScoped<IDespesaRepositorio, DespesaRepositorio>();

builder.Services.AddEndpointsApiExplorer();

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

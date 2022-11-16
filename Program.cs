using Microsoft.EntityFrameworkCore;
using GerenciadorFinanca.Data;
using GerenciadorFinanca.Repositorio.IContratos;
using GerenciadorFinanca.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;

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

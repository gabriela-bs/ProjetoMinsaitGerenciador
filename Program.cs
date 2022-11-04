using Microsoft.EntityFrameworkCore;
using GerenciadorFinanca.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version("8.0.31")))
);

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

app.UseAuthorization();

app.MapControllers();

app.Run();

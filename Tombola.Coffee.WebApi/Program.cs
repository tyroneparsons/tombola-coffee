using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Tombola.Coffee.WebApi.Data;
using Tombola.Coffee.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite((builder.Configuration.GetConnectionString(("DefaultConnection")))));

builder.Services.AddScoped<IBeanService, BeanService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();